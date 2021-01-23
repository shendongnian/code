    // Globals should be static
    public static class MyGlobals
    {
        public static long TotNum { get; private set; }
        public static long[] MyNumbers { get; private set; }   
        public static void SetNum(long num)
        {
            TotNum = num;
            MyNumbers = new long[TotNum + 1];
        }
    }
    // interacts with UI
    public static class UIHelper
    {
        public static long GetParam() 
        {
            Console.Write("n = ");
            var number = long.Parse(Console.ReadLine());
            return number;
        }
    }
    // Knows how to calc fibo
    static class Fibo 
    {
        static long Fibonacci(long[] nums, long n)
        {   
            ... calc fibonacci logic
        }        
    }
    
    class Program
        {
            static void Main(string[] args)
            {
                // now we can use them all
                // first lets get value from console
                var num = UIHelper.GetParam();
     
                // set global variables with this value
                MyGlobals.SetNum(num);
    
                // output result : 
                Console.WriteLine("Fib ({0}) = {1}", n, Fibonacci(MyGlobals.MyNumbers, MyGlobals.TotalNum));
    
                Console.ReadKey();
            }                
       }
