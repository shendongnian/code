    public class CallRestAPIController:ApiController
    {
        public async Task<string> PostToAPI([FromBody]string value)
        {
            var payload = value;
    
            // Serialize our concrete class into a JSON String
            var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(payload));
    
            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
    
            using (var httpClient = new HttpClient())
            {
    
                // Do the actual request and await the response
                var httpResponse = await httpClient.PostAsync("https://testapi.com/prod/testapi", httpContent);
    
                // If the response contains content we want to read it!
                if (httpResponse.Content != null)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();
                    // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
                    testModel test = new testModel();
                    object Desobj = JsonConvert.DeserializeObject(responseContent);
                    return test.Response = Desobj.ToString();
                }
                 return string.Empty;
            }
    
        }
    
    }
