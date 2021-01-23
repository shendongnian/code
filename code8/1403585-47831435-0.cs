    class Program
    {
        static void Main(string[] args)
        {
            Locks.DoStuff(Enumerable.Range(0, 10000).Select(e => 9999 - e).ToList());
        }
    }
    static class Locks
    {
        public static void DoStuff(List<int> blah)
        {
            try
            {
                lock (blah)
                {
                    for (var i = 0; i < blah.Count; i++)
                    {
                        blah[i] = 1000 / blah[i];
                    }
                }
            }
            catch (DivideByZeroException e)
            {
                Trace.WriteLine("Exception - divided by zero");
            }
        }
    }
