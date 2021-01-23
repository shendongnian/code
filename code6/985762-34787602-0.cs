    public class a
    {
        private int test;
        [JsonProperty]
        public int Test
        {
            get { return test; }
            private set { test = value; }
        }
        public string s { get; set; }
        [JsonProperty]
        public string anotherProperty { get; private set;}        
        public void set()
        {
            test = 33;
        }
    }
