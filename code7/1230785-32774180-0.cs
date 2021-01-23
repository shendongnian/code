    public class Registrar
    {
        public string id { get; set; }
        public string name { get; set; }
        public object email { get; set; }
        public string url { get; set; }
    }
    
    public class Response
    {
        public string name { get; set; }
        public string idnName { get; set; }
        public List<string> status { get; set; }
        public List<string> nameserver { get; set; }
        public object ips { get; set; }
        public string created { get; set; }
        public string changed { get; set; }
        public string expires { get; set; }
        public bool registered { get; set; }
        public bool dnssec { get; set; }
        public string whoisserver { get; set; }
        public List<object> contacts { get; set; }
        public Registrar registrar { get; set; }
        public List<string> rawdata { get; set; }
        public object network { get; set; }
        public object exception { get; set; }
        public bool parsedContacts { get; set; }
    }
    
    public class RootObject
    {
        public int error { get; set; }
        public Response response { get; set; }
    }
    
    ...
    RootObject result = JsonConvert.DeserializeObject<RootObject>(html);
    var created = result.response.created;
