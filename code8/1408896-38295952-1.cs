    [DataContract]
    public class MyObject : DynamicObject
    {
        [DataMember]
        public List<MyProperty> MyList { get; set; }
    }
