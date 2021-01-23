    class SimpleClass
    {
        static readonly long A;
        static readonly long B;
        static SimpleClass()
        {
            var ticks = DateTime.Now.Ticks;
            A = ticks;
            B = ticks;
        }
    }
