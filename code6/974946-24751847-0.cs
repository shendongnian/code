    [DataContract]
    public class MyClass
    {
        [DataMember]
        public string myId { get; set; }
        
        [DataMember]
        public List<MyClass2> otherClasses { get; set; }
    }
    [DataContract]
    public class MyClass2
    {
        [DataMember]
        public string myId { get; set; }
       
        [DataMember]
        public int someNumber { get; set; }
    }
