    public class Root : IRoot<Secondary, Tertiary> 
    {
        public Secondary secondary { get; set; }
        public Tertiary tertiary { get; set; }
    }
    
    public class Root2 : IRoot<Secondary2, Tertiary2> 
    {
        public Secondary2 secondary { get; set; }
        public Tertiary2 tertiary { get; set; }
    }
