    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter in an emplty line to exit...");
            var line= "";
            line = Console.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                Console.WriteLine(string.Format("You entered: {0}, Enter next or press enter to exit...", line));
                line = Console.ReadLine();
            }
        }
    }
