    public class Program
    {
        static void HelloWorld(int i)
        {
            Console.WriteLine("Hello World! " + i);
        }
    
        public static void Main(string[] args)
        {
            DelayedMethodCaller methodCaller = new DelayedMethodCaller(500);
            methodCaller.CallMethod(() => HelloWorld(123));
            methodCaller.CallMethod(() => HelloWorld(123));
            while (true)
                ;
        }
    }
