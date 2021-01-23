    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Services;
    using System.Web.Script.Serialization;
    
    [WebService]
    [ScriptService]
    
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getData()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>();
            Dictionary<string, object> item;
    
            // you must loop over data reader and 
            // - create dictionary
            // - set properties
            // - add to data
            // two examples below
            item = new Dictionary<string, object>();
            item.Add("id", 413);
            item.Add("title", "ranjan");
            item.Add("start", 413);
            item.Add("end", 413);
            data.Add(item);
    
            item = new Dictionary<string, object>();
            item.Add("id", 414);
            item.Add("title", "raja");
            item.Add("start", 414);
            item.Add("end", 414);
            data.Add(item);
    
            return new JavaScriptSerializer().Serialize(data);
        }
    }
