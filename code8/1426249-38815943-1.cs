    [DataContract]
    class ExampleClass
    {
        public ExampleClass()
        {
            method =  "Example Constant"; 
        }
    
        [DataMember(Name = "method")]
        private string method;
