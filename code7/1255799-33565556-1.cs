    class Program
    {
        static void Main(string[] args)
        {
            callFunction(10, (i) =>
            {
                //printf( i ); 
            });
        }
        delegate void someDelegate(int i);
        public static void callFunction(int i, someDelegate del)
        {
            del.Invoke(i);
        }
    }
