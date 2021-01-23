    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Services;
    
    namespace MvcApiApplicationTrial1.Controllers
    {
      public class ActionController : ApiController
      {
        [WebMethod]
        public string getCommunities() {
          try {
            MethodClass method = new MethodClass();
            return method.getCommunities();
          } catch (Exception ex) {
            return ex.Message.ToString();
          }
        }
      }
    
      public class MethodClass
      {
        public string getCommunities() {
          return "bbb";
        }
      }
    }
