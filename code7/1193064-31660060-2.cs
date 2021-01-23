    // Add interfece for accessing Google API
    public interface IGoogleClient
    {
        string GetData(string data);
    }
    // Then implementation is identical to MethodB implementation:
    public class GoogleClient : IGoogleClient
    {
        public string GetData(string data)
        {
            using (var client = new HttpClient())
            {
            //...make call to Google API...
            }
        }
    }
    // Your controller should look like this:
    public class OrderController : ApiController
    {
        private readonly IRepositoryK repositoryk;
        private readonly IGoogleClient googleClient;
        public OrderController(IRepositoryK repositoryk, IGoogleClient googleClient)
        {
            this.googleClient = googleClient;
            this.repositoryk = repositoryk;
        }
        public HttpResponseMessage NewOrder()
        {
           //...snip....
           string x = repositoryk.MethodA("stuff", "moreStuff", MethodB("junk"));
        }
        public string MethodB(string data)
        {
            return googleClient.GetData(data);
        }
    }
