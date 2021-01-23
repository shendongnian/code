    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            string number = ReadNumber();
            Console.WriteLine("You entered: " + number);
        }
        private static string ReadNumber()
        {
            string input = "";
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (char.IsNumber(keyInfo.KeyChar))
                {
                    input = input + keyInfo.KeyChar;
                    Console.Write(keyInfo.KeyChar);
                }
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    input = input.Substring(0, input.Length - 1);
                    Console.Write("\b \b");
                }
            } while (true);
 
            return input;
        }
    }
