    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class lpService : System.Web.Services.WebService
    {
        [WebMethod]
        public string GreetUser(string name)
        {
            return String.Format("Hello {0}",name);
        }
    }
