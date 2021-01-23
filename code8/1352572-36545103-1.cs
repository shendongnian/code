<!-- language: lang-html -->    
    namespace ConsoleApplication1
    {
        class Program
        {
            public static int myFunction(int x)
            {
                return x + 2;
            }
            static void Main(string[] args)
            {
                Console.WriteLine(myFunction(14));
                Console.ReadLine();
            }
        }
    }
