    [DataContract]
    public class PosMenu
    {
        [DataMember]
        public int VenueId { get; set; }
    
        [DataMember]
        public int Count { get; set; }
    
        [DataMember]
        public PosMenuEmbedded Embeded { get; set; }
    }
    
    [DataContract]
    public class PosMenuEmbedded
    {
        [DataMember]
        public long UniqueId { get; set; }
    
        [DataMember]
        public PosMenuCategory[] Categories { get; set; }
    
        [DataMember]
        public int PosMenuId { get; set; }
    }
