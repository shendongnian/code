    public class MyClass
    {
        int dtm;
        double lastPrice = 0;
        public static Chart chart_ { get; set; }
        public int Dtm
        {
            get { return dtm; }
            set { dtm = value; }
        }
        public double LastPrice
        {
            get { return lastPrice; }
            set { lastPrice = value; chart_.DataBind(); }
        }
         // a constructor to make life a little easier:
        public MyClass(int dt, double lpr)
        { Dtm = dt; LastPrice = lpr; }
    }
