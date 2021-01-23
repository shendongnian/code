    public class Service : System.Web.Services.WebService, IServiceSoap 
    {
          public string HelloWorld(string i)
          {
              return "foo";
          }
    }
