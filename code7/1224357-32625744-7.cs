    public class SiteMapNodeDto
    {
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public string Title { get; set; }
        public IDictionary<string, object> RouteValues { get; set; }
        // Additional properties...
    }
