        static void Main(string[] args)
        {
            string inputStr = Console.ReadLine();
            byte[] bytes = Encoding.Unicode.GetBytes(inputStr);
            string str = Encoding.Unicode.GetString(bytes);
            Console.WriteLine(inputStr == str); // true
        }
