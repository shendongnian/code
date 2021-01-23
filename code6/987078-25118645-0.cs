    string _eId;
    [JsonProperty("entity")]
        private string EntityIdentifier 
        { 
            get{return _eId;}
            set
            {
                _eId = value;
                Entity = someMethodToRetrieveTheEntityById(_eId);
            }
        }
