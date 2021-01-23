    public class JsonObject
    {
        public object Value { get; set; }
        public string Type { get; set; }
    }
    var s = "{'Value':{'something':'test'},'Type':'JsonData'}";
    var o = DeserializeCore(typeof(JsonObject), Encoding.UTF8.GetBytes(s.ToCharArray()));
