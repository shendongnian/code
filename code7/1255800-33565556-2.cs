    class Program
    {
        static void Main(string[] args)
        {
            callFunction(10, (i) =>
            {
                //printf( i ); 
            });
        }
        public delegate void someDelegate(int i);
        public static void callFunction(int i, someDelegate del)
        {
            del.Invoke(i);
        }
    }
