    // at the top of the file add
    using Any.AweSome.NameSpace;
    // NO MORE ATTRIBUTES HERE! 
    // NOTICE the IServiceSoap at the end
    public class Service : System.Web.Services.WebService, IServiceSoap 
    {
          // AND ALSO NO MORE ATTRIBUTES HERE
          public string HelloWorld(string i)
          {
              return "foo";
          }
    }
