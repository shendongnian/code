    public class ApiService
    {
        public static HttpClient GetClient()
        {
            var client = new HttpClient(new Uri("https://someservice/"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
            //add any other setup items here.
            return client;
        }
    }
