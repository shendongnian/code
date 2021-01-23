    //Model for the data you are sending
    public class TestModel
    {
        public string Name { get; set; }
    }
    //define client, request and model
    var client = new RestClient {BaseUrl = new Uri("http://myhost.com:22333") };        
    var request = new RestRequest { Method = Method.POST, Resource = "/site/api", RequestFormat = DataFormat.Json };
    var testModel = new TestModel() { Name = "joe" };
    //serialize model as json and add it to the request
    var json = request.JsonSerializer.Serialize(testModel);
    request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
    //execute request
    IRestResponse response = client.Execute(request);
