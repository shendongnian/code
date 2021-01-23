    class Super
    {
        public static char methodA() 
        {
            return 'a'; 
        }
    }
    class Sub : Super
    {
        public static char methodA() 
        {
            return 'b'; 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var res = Sub.methodA();
            var res2 = Super.methodA();
            Console.WriteLine(res == res2);
            Console.ReadKey();
    }
