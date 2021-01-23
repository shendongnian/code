    using Newtonsoft.Json;
    // ...
    class Response
    {
        [JsonProperty(PropertyName = "myapiresult")]
        public string ApiResult { get; set; }
    }
    
    void Main()
    {
        string responseJson = "{\"myapiresult\":\"successfull\"}";
        Response response = JsonConvert.DeserializeObject<Response>(responseJson);
        Console.WriteLine(response.ApiResult);
        // Output: successfull
    }
