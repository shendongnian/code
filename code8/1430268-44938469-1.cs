    #r "Newtonsoft.Json"
    using System.Net;
    using Newtonsoft.Json;
    using System.Text;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        var myObj = new {name = "thomas", location = "Denver"};
        var jsonToReturn = JsonConvert.SerializeObject(myObj);
    
        return new HttpResponseMessage(HttpStatusCode.OK) {
            Content = new StringContent(jsonToReturn, Encoding.UTF8, "application/json")
        };
    }
