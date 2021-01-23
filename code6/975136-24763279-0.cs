    [DataContract]
    public class YourClass
    {
        [DataMember(Name = "41")]
        public YourEntity Property41
        {
            get;
            set;
        }
    }
    [DataContract]    
    public class Entity 
    {
       [DataMember(Name = "entity_id")]
       public int EntityID { get; set; }
    }
