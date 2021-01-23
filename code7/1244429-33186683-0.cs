    public class Program
    {
        public static void Main()
        {
    
            ConsoleKeyInfo keyinfo;
            do
            {
                keyinfo = Console.ReadKey();
                Console.WriteLine(keyinfo.Key + " was pressed");
            }
            while (keyinfo.Key != ConsoleKey.Enter);
        }
    }
