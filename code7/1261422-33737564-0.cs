    [DataContract]
    public class Action
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [DataMember]
        public string ActionName { get; set; }
    }
