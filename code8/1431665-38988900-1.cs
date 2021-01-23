    public class Test
    {
        public string Show { get; set; }
    
        public Test Get(string s)
        {
            Show = s;
            return this;
        }
    }
