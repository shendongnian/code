    class DoubleRandomBuilder : IRandomTypeBuilder
    {
        static Random rng = new Random();        
        public object GetNext()
        {
            return rng.NextDouble() * rng.Next(0, 1000);
        }
    }
    
    class IntRandomBuilder : IRandomTypeBuilder
    {
        static Random rng = new Random();
        public object GetNext()
        {
            return rng.Next(int.MinValue, int.MaxValue);
        }
    }
    
    class StringRandomBuilder : IRandomTypeBuilder
    {
        static Random rng = new Random();
        static string aplha = "abcdefghijklmnopqrstuvwxyz";
        public object GetNext()
        {
            string next = "";
            for (int i = rng.Next(4, 10), j = i + rng.Next(1, 10); i < j; i++)
                next += aplha[rng.Next(0, aplha.Length)];
            return next;
        }
    }
    
    class BoolRandomBuilder : IRandomTypeBuilder
    {
        static Random rng = new Random();
        public object GetNext()
        {
            return rng.Next(0, 2) % 2 == 0;
        }
    }
