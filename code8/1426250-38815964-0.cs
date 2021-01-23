    [DataContract]
    class ExampleClass
    {
        private const string method = "Example Constant"; 
        //Properties
        [DataMember(Name = "method")]
        public string Method { get; set; }
        public ExampleClass(this.Method = method; }
    }
