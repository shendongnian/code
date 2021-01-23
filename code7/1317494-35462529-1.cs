    // option 1:  private member
        public partial class test
        {
            private int _active = 1;
            public int Id { get; set; }
            public string test1 { get; set; }
            public int active 
            { 
                get {return _active; } 
                set {_active = value; } 
            }
        }
    
    // option 2:  initialize in constructor
    
        public partial class test
        {
            public test()
            {
                active = 1;
            }
            public int Id { get; set; }
            public string test1 { get; set; }
            public int active { get; set; }
        }
