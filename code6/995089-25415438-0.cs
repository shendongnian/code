    [DataContract(Namespace = "")]
    public class Status
    {
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Option { get; set; }
        private string value;
        [DataMember]
        public string Value
        {
            get { return this.value ?? ""; }
            set { this.value = value; }
        }
    }
