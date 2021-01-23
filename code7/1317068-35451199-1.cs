    public class RootObject
    {
        [JsonProperty("json")]
        public Json jsonobj;
    }
     public class Json
    {
        [JsonProperty("#thekeyinsidejsonproperty")]
        public string somepropertyname{ get; set; }
    }
