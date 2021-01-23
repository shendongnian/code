    public class B
    {
        [JsonProperty]
        private A a;
        public B(A a)
        {
            this.a = a;  // be sure to set the A member in your constructor
        }
    }
