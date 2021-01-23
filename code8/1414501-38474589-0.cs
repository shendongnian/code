    var json = @"{""dateRemiseCandidature"": ""25/07/2016 00:00""}";
    var settings = new JsonSerializerSettings
    {
        DateFormatString = "dd/MM/yyyy hh:mm"
    };
    var result = JsonConvert.DeserializeObject<SomeClass>(json, settings);
    //////
    class SomeClass
    {
        public DateTime dateRemiseCandidature { get; set; }
    }
