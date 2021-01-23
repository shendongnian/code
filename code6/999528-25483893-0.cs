        private static Object lockObj = new Object();
        private class Value
        {
            public double X;
        }
        private class Aggregator
        {
            private Value myval = new Value();
            public void Add()
            {
                // use Min() instead of Max() -> bug disappears
                lock (lockObj)
                { 
                    myval.X = Math.Max(0, myval.X);
                }
            }
        }
        public static void Main(string[] args)
        {
            Parallel.For(0, 10000, Process);
        }
        private static void Process(int k)
        {
            Value[] V = new Value[10000];
            Aggregator aggregator = new Aggregator();
            for (int i = 0; i < V.Length; i++)
            {
                V[i] = new Value();
                aggregator.Add();
            }
        }
