    [DataContract]
    class Example
    {
        public Example()
        {
            ExampleArray = new int[] {1, 2};
        }
    
        [DataMember]
        int[] ExampleArray {get; set;}
    }
