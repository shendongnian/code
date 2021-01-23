    //generated with json2csharp
    //each class correspond to the json string retrieve by the back end
    
    //{"href":"http://api.iolab.net/v1/exams/0"}
    public class Self
    {
        public string href { get; set; }
    }
    //"_links":{"self":{"href":"http://api.iolab.net/v1/exams/0"}
    public class Links
    {
        public Self self { get; set; }
    }
    
    //{"items":[{"id":0,"shortname":"NETD","_links":{"self":{"href":"http://api.iolab.net/v1/exams/0"}}}]}
    public class Item
    {
        public int id { get; set; }
        public string shortname { get; set; }
        public Links _links { get; set; }
    }
    
    //Rott object
    public class RootObject
    {
        public List<Item> items { get; set; }
    }
