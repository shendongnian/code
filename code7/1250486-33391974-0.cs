    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var test = new Test())
            {
                test.Foo();
            }
    
            Console.ReadLine();
        }
    }
