    [WebService(Namespace = "http://example.com/")] 
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]System.Web.Services.WebService
    [ScriptService]
    public class services :WebService  
    {    
        [WebMethod(CacheDuration = 60)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public List<TestObject> GetObjectCollection()
        {
               return YourService.GetObjectCollection().ToList();
        }
    }
