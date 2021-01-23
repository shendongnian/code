    [DataContract]
    public class Car
    {
        [IgnoreDataMember]
        public int ID;
    
        [DataMember]
        public string CarName;
    
        [DataMember]
        public string CarType;
    
    }
