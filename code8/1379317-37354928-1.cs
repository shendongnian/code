    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    public class Account
    {
        public int AccountID { get; set; }
    
    }
    public class BusinessAccount : Account
    {
        public string BusinessAddress { get; set; }
    }
    
    public class Package<T>
    {
        public T Data { get; set; }
    }
    
    /// <summary>
    /// using fiddler, I made a request to http://localhost/api/account
    /// and got
    /// 
    /// {"Data":{"BusinessAddress":"ABC","AccountID":123}}
    /// 
    /// without making any configuration.
    ///  
    /// 
    /// </summary>  
    namespace test
    {
        public class AccountController : ApiController
        {
            // GET api/<controller>
            public Package<BusinessAccount> Get()
            {
                return new Package<BusinessAccount>()
                {
                    Data = new BusinessAccount()
                    {
                        AccountID = 123,
                        BusinessAddress = "ABC"
                    }
                };
            }
        }
    }
