    public class DeCrash
    {
        [JsonProperty("object_I_Need")]
        protected JObject ObjectINeed;
        [JSonProperty("typeindicator")]
        public String TypeIndicator { get; set; }
        [JsonIgnore]
        public TypeA ObjectA 
        { 
            get 
            { 
               return TypeIndicator == "A" ? ObjectINeed.ToObject<TypeA> : null;
            }
        }
        [JsonIgnore]
        public TypeB ObjectB
        { 
            get 
            { 
               return TypeIndicator == "B" ? ObjectINeed.ToObject<TypeB> : null;
            }
        }
    }
              
