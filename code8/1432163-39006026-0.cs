    class Program
    {
        readonly int x;
        public Program()
        {
            Volatile.Write(ref x, 1);
        }
    }
