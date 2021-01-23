    public class Backend
    {
        public string os { get; set; }
        public string id { get; set; }
        public int requestsProcessed { get; set; }
    }
    
    public class Meta
    {
        public bool outputAsJson { get; set; }
        public Backend backend { get; set; }
    }
    
    public class PageRequest
    {
        public string renderType { get; set; }
        public bool outputAsJson { get; set; }
    }
    
    public class FrameData
    {
        public string name { get; set; }
        public int childCount { get; set; }
    }
    
    public class Event
    {
        public string key { get; set; }
        public string time { get; set; }
    }
    
    public class ScriptOutput
    {
        public List<object> items { get; set; }
    }
    
    public class PageRespons
    {
        public PageRequest pageRequest { get; set; }
        public FrameData frameData { get; set; }
        public List<Event> events { get; set; }
        public ScriptOutput scriptOutput { get; set; }
        public int statusCode { get; set; }
    }
    
    public class Content
    {
        public string name { get; set; }
        public string encoding { get; set; }
    }
    
    public class Page
    {
        public string renderType { get; set; }
        public bool outputAsJson { get; set; }
    }
    
    public class OriginalRequest
    {
        public List<Page> pages { get; set; }
    }
    
    public class RootObject
    {
        public Meta meta { get; set; }
        public List<PageRespons> pageResponses { get; set; }
        public int statusCode { get; set; }
        public Content content { get; set; }
        public OriginalRequest originalRequest { get; set; }
    }
