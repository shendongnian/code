    static void Main(string[] args)
    {
        Xb x1 = new X1()
        {
            y1 = 1,
            y2 = 2
        };
        Xb x2 = new X2()
        {
            y1 = 1,
            y2= 2
        };
       bool result = new Comparator<Xb>().Equals(x1, x2);
    }
    }
    
    class Xb
    {
        public int y1 { get; set; }
    }
    
    class X1 : Xb
    {
        public short y2 { get; set; }
    }
    class X2 : Xb
    {
        public long y2 { get; set; }
    }
