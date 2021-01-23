    In your myfunction method your returning some int value but myfunction return type is void in your code..Plaese change void to int and the application.It will work.
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
