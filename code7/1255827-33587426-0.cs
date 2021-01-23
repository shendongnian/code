    [DataContract]
    public class MyNameValueInfo
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
    
        [DataMember(Order = 2)]
        public object Value { get; set; }
    }
