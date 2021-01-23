    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Web.Script.Serialization;
    using System.Web.Services;
    
    namespace WebApplication1
    {       
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        [System.Web.Script.Services.ScriptService]
        public class SuperWebSvc : System.Web.Services.WebService
        {    
            [WebMethod]
            public string GetData()
            {
                Dictionary<string, string> name = new Dictionary<string, string>();
                name.Add("1", "Luke Skywalker");
                name.Add("2", "Han Solo");
                string myJsonString = (new JavaScriptSerializer()).Serialize(name);
                Thread.Sleep(5000); // wait for 5 seconds, this is just for demo purposes
                return myJsonString;
            }
        }
    }
