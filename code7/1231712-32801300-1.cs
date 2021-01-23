    class Program
    {
        public static void Main(string[] args)
        {
            var arr = new byte[] { 10 };
            Console.WriteLine(arr[0]); // prints 10
            DoSomething(arr);
            Console.WriteLine(arr[0]); // prints 11
        }
        private static void DoSomething(byte[] arr)
        {
            arr[0] = 11;
        }
    }
