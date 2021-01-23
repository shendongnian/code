    public static void Main()
    {
        //read all lines from file only once, and keep for future use
        var currencyDetails = File.ReadAllLines(@"C:\YourDirectory\currencies.txt"); 
        string input = string.Empty;
        while (true) //keep looping until empty input by user
        {
            Console.Write("Enter currency code > ");
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) //stop loop
                break;
            //from all lines of file, get the line where line starts with the user input e.g. usd
            var currencyDetail = currencyDetails.FirstOrDefault(l => l.StartsWith(input.ToUpper()));
            if (currencyDetail != null) //if a matching currency is found, show it
            {
                Console.WriteLine(currencyDetail);
            }
        }
        Console.ReadLine();
    }
