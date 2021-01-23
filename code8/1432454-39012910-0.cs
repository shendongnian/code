    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input BackgroundColor:");
            string bcolor = Console.ReadLine();
            Console.WriteLine("input ForegroundColor:");
            string fcolor = Console.ReadLine();
            ChangeColorConsole(bcolor, fcolor);
            Console.Read();
        }
        static void ChangeColorConsole(string bvalue, string fvalue)
        {
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), bvalue);
            Console.Clear();
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), fvalue);
        }
    }
