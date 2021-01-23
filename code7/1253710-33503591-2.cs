    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    delegate int ComputeCallback(int value);
    class Program
    {
        [DllImport("server.dll")]
        public static extern int Sum(ComputeCallback callback); 
        static void Main(string[] args)
        {
            ComputeCallback callback = x =>
            {
                Console.WriteLine("Computing. X = {0}", x);
                return x*x;
            };
            Console.WriteLine("Result: {0}", Sum(callback));
        }
    }
