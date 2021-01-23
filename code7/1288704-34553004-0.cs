    static void Main(string[] args)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if input.StartsWith("print:")
                Console.WriteLine(input.Replace("print:", ""));
        }
    }
    
