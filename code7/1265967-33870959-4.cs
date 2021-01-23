    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine(new Class1().Message());
                Console.WriteLine(Settings.Default.Message);
                Console.ReadKey();
            }
        }
    }
