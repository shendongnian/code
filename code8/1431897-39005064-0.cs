    public class TypeA
    {
        public DateTime date { get; set; }
        public void Print() { Console.WriteLine("TypeA: " + date.ToString()); }
    }
    public class TypeB
    {
        public DateTime date { get; set; }
        public void Print() { Console.WriteLine("TypeB: " + date.ToString()); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // setup
            var X = new List<TypeA>();
            var Y = new List<TypeB>();
            Random rnd = new Random();
            int imin, imax;
            imin = rnd.Next(3, 7);
            imax = rnd.Next(10, 20);
            for (int i = imin; i < imax; i++)
            {
                X.Add(new TypeA() { date = DateTime.Now.AddDays(-1 * rnd.Next(1, 1000)) });
            }
            imin = rnd.Next(3, 7);
            imax = rnd.Next(10, 20);
            for (int i = imin; i < imax; i++)
            {
                Y.Add(new TypeB() { date = DateTime.Now.AddDays(-1 * rnd.Next(1, 1000)) });
            }
            X = X.OrderBy(z => z.date).ToList();
            Y = Y.OrderBy(z => z.date).ToList();
            // begin print in order
            // index for X list
            int ix = 0;
            // index for Y list
            int iy = 0;
            // most recently printed date
            DateTime min = DateTime.MinValue;
            while (true)
            {
                if (ix < X.Count && X[ix].date >= min && (iy >= Y.Count || iy < Y.Count && X[ix].date <= Y[iy].date))
                {
                    X[ix].Print();
                    min = X[ix].date;
                    ix++;
                    continue;
                }
                if (iy < Y.Count && Y[iy].date >= min)
                {
                    Y[iy].Print();
                    min = Y[iy].date;
                    iy++;
                }
                if (ix >= X.Count && iy >= Y.Count)
                {
                    break;
                }
            }
        }
    }
