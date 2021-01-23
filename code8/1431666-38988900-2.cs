    public class Test
    {
        public string Show { get; set; }
    
        public Test ConfigureShow(string show)
        {
            Show = show;
            return this;
        }
    }
