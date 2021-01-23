    namespace ConsoleApplication3
    {
        using System;
    
        using RestSharp;
    
        public class Program
        {
            public static void Main()
            {
    			string appId = "YOUR APP ID HERE";
    			string appKey = "YOUR APP KEY HERE";
                var client = new RestClient("https://api.kairos.com");
    			var request = new RestRequest("detect", Method.POST);
    
    			// automatically makes the request body serialize as JSON
    			request.RequestFormat = DataFormat.Json;
    			request.AddBody(new { image = "http://media.kairos.com/kairos-elizabeth.jpg" });
    			request.AddHeader("app_id", appId);
    			request.AddHeader("app_key", appKey);
    
    			var response = client.Execute(request);
    
    			// handle response however you want, but I'm just going to print it out
    			Console.WriteLine(response.Content);
            }
        }
    }
