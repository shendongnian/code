    [DataContract]
    public class User
    {
        [DataMember]
        public long ID;
        [DataMember]
        public string Logon;
        string _features = null;
        [IgnoreDataMember]
        public string Features
        {
            get
            {
                return _features;
            }
            set
            {
                if (value == null)
                    _features = null;
                else
                {
                    JToken.Parse(value); // Throws an exception on invalid JSON.
                    _features = value;
                }
            }
        }
        [DataMember(Name="Features")]
        JToken FeaturesJson
        {
            get
            {
                if (Features == null)
                    return null;
                return JToken.Parse(Features);
            }
            set
            {
                if (value == null)
                    Features = null;
                else
                    Features = value.ToString(Formatting.Indented); // Or Formatting.None, if you prefer.
            }
        }
    }
