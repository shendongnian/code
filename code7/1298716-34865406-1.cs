    [DataContract]
    public class Person
    {
        [DataMember(Name = "$schema")]
        public string schema= {get;set; }
        public string name {get;set; }
        public int age {get; set;}
    }
