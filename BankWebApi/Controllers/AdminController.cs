using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModelLayer;
using Newtonsoft.Json;


namespace WebApiDemo.Controllers
{
    public class AdminController : ApiController
    {
        AdminService adminservice;
        public AdminController()
        {
            adminservice = new AdminService();
        }


        [HttpGet]
        public IHttpActionResult GetAccountDetail()
        {
            var result = adminservice.GetAccountDetail();
            return Ok<IList<AccountDetail>>(result);
        }

        [HttpGet]
        public IHttpActionResult GetDeposits()
        {
            //var ss = request.Content.ReadAsStringAsync();
            //Deposits ds = Json.Parse<Deposits>(ss);
            var res = adminservice.GetDeposits();
            return Ok<IList<Deposits>>(res);
        }

        [HttpGet]
        public IHttpActionResult GetLoans()
        {
            
            var res = adminservice.GetLoans();
            return Ok<IList<Loans>>(res);
        }
        [HttpPost]
        public void CreateAccount(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            CreateUser ds = JsonConvert.DeserializeObject<CreateUser>(ss);
            adminservice.CreateAccount(ds);

        }
        [HttpPost]
        public void ApproveLoans(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt16(ss);
            adminservice.ApproveLoans(i);

        }
        [HttpPost]
        public void ApproveDeposits(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            int i = Convert.ToInt16(ss);
            adminservice.ApproveDeposits(i);

        }
        [HttpPost]
        public void CloseAccount(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            Int64 i = Convert.ToInt64(ss);
            adminservice.CloseAccount(i);

        }
        [HttpPost]
        public void UpdateAccount(HttpRequestMessage request)
        {
            string ss = request.Content.ReadAsStringAsync().Result;
            CreateUser ds = JsonConvert.DeserializeObject<CreateUser>(ss);
            adminservice.UpdateAccount(ds);

        }

    }
}
