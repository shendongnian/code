    [DataContract]
    public class Person
    {
        [DataMember(Name = "$schema")]
        public string schema= @"http://example.com/person.json";
        public string name {get;set; }
        public int age {get; set;}
    }
