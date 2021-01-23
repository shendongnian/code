    [DataContract]
    public class MyClass
    {
        public MyClass()
        {
            this.A = "a";
            this.b = "b";
        }
        [DataMember]
        public string A { get; set; }
        [DataMember]
        public string b { get; set; }
    }
