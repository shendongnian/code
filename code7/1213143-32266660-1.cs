    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {   
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        
        [WebMethod]
        public string btn(string surname, string name)
        {
            return surname + " " + name;
        }  
    }
