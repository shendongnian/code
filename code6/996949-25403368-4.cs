    using System.Web.Script.Services;
    using System.Web.Services;
    namespace Whatever {
      [WebService(Namespace = "http://tempuri.org/")]
      [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
      [System.ComponentModel.ToolboxItem(false)]
      [ScriptService]
      public class andSert : System.Web.Services.WebService {
        [ScriptMethod(UseHttpGet = true)]
        [WebMethod]
        public string GetMessage() {
          return "Hello World";
        }
      }
    }
    
