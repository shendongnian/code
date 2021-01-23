    /// <summary>
    /// Summary description for HelloWorld
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HelloWorld : System.Web.Services.WebService
    {
    
        [WebMethod]
        public string GetHelloWorld()
        {
            return "Hello World";
        }
    }
