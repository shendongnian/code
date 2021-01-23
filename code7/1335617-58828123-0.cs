    IEnumerable<WrapperItem> items = WebContentParser.ParseList<WrapperItem>(html);
    
    // ...
    
    [ListSelector(".wrapper", ChildSelector = ".row")]
    class WrapperItem
    {
        [Selector("div:nth-child(1)")]
        public string Value1 { get; set; }
        
        [Selector("div:nth-child(2)")]
        public string Value2 { get; set; }
    }
