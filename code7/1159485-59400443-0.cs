    namespace GlobalConsoleWithSharedProject1
    {
        class Program
        {
            public static string RandomName { get; set; }
            static void Main(string[] args)
            {
                RandomName = "Bill";
                Console.WriteLine($"RandomName before {RandomName}");
                var bozo = new Class1();
                bozo.ChangeRandomName();
                Console.WriteLine($"RandomName after {RandomName}");
            }
        }
    }
