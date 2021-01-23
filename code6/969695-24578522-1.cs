    namespace ConsoleApplication1 
    { 
        class Program 
        { 
            static void Main(string[] args) 
            { 
                int x = 3; 
                Console.WriteLine(x.factorial()); 
                Console.ReadLine(); 
            } 
        } 
            public static class MyMathExtension 
            { 
                public static int factorial(this int x) 
                { 
                    if (x <= 1) return 1; 
                    if (x == 2) return 2; 
                    else 
                        return x * factorial(x - 1); 
                } 
            }
        }
