    [DataContract]
    public class Action
    {
        [DataMember]
        [Key] //This isn't technically needed, but I prefer to be explicit.
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
    
        [DataMember]
        public string ActionName { get; set; }
    }
