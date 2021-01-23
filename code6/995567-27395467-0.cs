    [DataContract]
    public class Data
    {
        public Data()
        {
            Attributes = new Dictionary<string, object>();
        }
                    
        [DataMember]
        public Dictionary<string, object> Attributes { get; set; }
    
        [IgnoreDataMember]
        public object this[string index]
        {
            set { Attributes[index] = value; }
            get
            {
                if (Attributes.ContainsKey(index))
                    return Attributes[index];
                else
                    return null;
            }
        }
    }
