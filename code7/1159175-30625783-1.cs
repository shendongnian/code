    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            do
            {
                //Print command
                string print = Console.ReadLine();
                if (print.ToLowerInvariant().StartsWith("print: "))
                {
                    string p2 = print.Substring(print.IndexOf(' ') + 1);
                    Console.WriteLine(p2);
                }
    
                string variable = Console.ReadLine();
                if (variable.ToLowerInvariant().StartsWith("var "))
                {
                    string v2 = variable.Substring(variable.IndexOf(' ') + 1);
                }
            }
            while (true);
        }
    }
