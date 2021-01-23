    [DataContract(Namespace = "http://my.company.com/contracts")]
    public class Person
    {
        private string name;
        private string email;
        private TimeSpan istZeit;
    
        public Person()
        {
    
        }
    
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    
        [DataMember]
        public TimeSpan IstZeit
        {
            get { return istZeit; }
            set { istZeit = value; }
        }
    
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
