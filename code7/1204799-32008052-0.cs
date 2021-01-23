    [System.Web.Script.Services.ScriptService]
    public class Ajax2 : System.Web.Services.WebService
    {
        [WebMethod]
        public string SayHello(string name)
        {
            return "Hello " + name; 
        }
    }
