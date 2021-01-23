        class SomeJsonObject
        {
            public int rate {get;set;}
            [JsonProperty("information")] //if you want to name your property something else
            public InformationObject Information {get;set;}
        }
        class InformationObject 
        {
            [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)] //some other things you can do with Json
            public int Height {get;set;}
            public int ssn {get;set;}
            public string name {get;set;}
        }
