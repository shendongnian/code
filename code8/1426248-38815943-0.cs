    [DataContract]
    class ExampleClass
    {
        public ExampleClass()
        {
            // assign property value in constructor
            Method = "Example Constant";
        }
    
        // changed constant to property
        [DataMember(Name = "method")]
        public string Method { get; set}
