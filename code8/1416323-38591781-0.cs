    [KnownType(typeof(YourSpecialObject))]
        [DataContract]
        public abstract class BusinessObjectInfo
        {
            [DataMember]
            public int Id { get; set; }
    
            [DataMember]
            public Byte[] Version { get; set; }
    
        }
