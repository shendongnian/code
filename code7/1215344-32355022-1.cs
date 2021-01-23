         public List<string> social { get; set; }
    }
    public class RootObject
    {
        public string name { get; set; }
        public string age { get; set; }
        public Info info { get; set; }
    }
    
    ...
    RootObject JSON= new JavaScriptSerializer().Deserialize<RootObject>(myJSONData);
    ...
