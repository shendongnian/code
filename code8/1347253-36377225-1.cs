    public class Root
    {
        [JsonProperty(PropertyName = "en.pickthall")]
        public object EnPickthall { get; set; }
        public Root() {}
        public Root(en_pickthall)
        {
            this.EnPickthall = en_pickthall;
        }
    }
