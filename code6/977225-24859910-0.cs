     public partial class TheWebServiceSubClass : ExampleService
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            HttpWebRequest webRequest = (HttpWebRequest)base.GetWebRequest(uri);
            ExampleService client = new ExampleService();
            string auth_id = client.authenticate_get("www.testexample.com", "e5d30c56d600a7456846164");
            string credentials =
                Convert.ToBase64String(Encoding.ASCII.GetBytes("www.testexample.com:e5d30c56d600a7456846164"));
            string credentials1 = Convert.ToBase64String(Encoding.ASCII.GetBytes(auth_id+ ":"));
            webRequest.Headers["Authorization"] = "Basic " + credentials1;
            return webRequest;
        }
    }
