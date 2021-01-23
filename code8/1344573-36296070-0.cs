    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    ...
    class Request1
    {
        public double CodValue { get; set; }
    }
    ...
    var request = new {Request1 = new Request1()};
    var json= JsonConvert.SerializeObject(request,
        new JsonSerializerSettings() {ContractResolver = new CamelCasePropertyNamesContractResolver()});
