    class T
    {
        public int Number { get; private set; }  // public property
        public T(int number)
        {
            Number = number;
        }
    }
    static class Extensions
    {
        public static void PrintT(this T t)
        {
            if (t == null) Console.WriteLine("null");
            else Console.WriteLine(t.Number);
        }
    }
    T t = null;
    t.PrintT(); // no exception, writes "null" to the console
