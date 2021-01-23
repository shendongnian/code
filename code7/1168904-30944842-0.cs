    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ServiceModel.Activation;
    namespace OldWSTest
    {
       /// <summary>
       /// Summary description for Service1
       /// </summary>
       [WebService(Namespace = "http://tempuri.org/")]
       [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
       [System.ComponentModel.ToolboxItem(false)]
       [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
       public class Service1 : System.Web.Services.WebService
       {
    
          [WebMethod]
          public string uploadAP()
          {
             var foo = HttpContext.Current.Request.Form["ap"];
    
             byte[] bytes = System.Text.Encoding.UTF8.GetBytes(foo);
             // do whatever you need with the bytes here
             return "done";
          }
       }
    }
