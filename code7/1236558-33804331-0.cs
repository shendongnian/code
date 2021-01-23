    internal class ODataError
        {
            [JsonProperty("odata.error")]
            public ODataErrorCodeMessage Error { get; set; }
        }
    
        internal class ODataErrorCodeMessage
        {
            public string Code { get; set; }
    
            public ODataErrorMessage Message { get; set; }
    
            public List<ExtendedErrorValue> Values { get; set; }
        }
    
        internal class ExtendedErrorValue
        {
            public string Item { get; set; }
    
            public string Value { get; set; }
        }
    
        internal class ODataErrorMessage
        {
            public string Lang { get; set; }
    
            public string Value { get; set; }
        }
