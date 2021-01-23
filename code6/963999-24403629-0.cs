    Class A
    {
        public string Something { get; set; }
        List<B> collection = new List<b>();
        public void Add(B b)
        {
            b.Master = this;
            collection.Add(b);        
        }
    }
    
    Class B
    {
        public A Master {get; set;}
        public int Num { get; set; }
    }
    static void Main(string[] args)
    {
        B b = new B();
        b.Num = 5;
    
        A a = new A();
        a.Something = "Hello";
        a.Add(b);
        Console.Writeline(b.Master.Something);
    }
