    static void Main(string[] args)
    {
        var filePath = "Your path of the location" + "filename.csv";
    
        Console.WriteLine("Insert a number followed by name and finally another number");
        Console.WriteLine("* Note: Insert all values separated by commas (ex: 10,Jesus,2000)");
        Console.WriteLine("* Note: Enter a blank line to exit");
    
        while(true) // Ad infinitum
        {
            var input = Console.ReadLine();
    
            // on blank line, confirm before exiting the application
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Do you want to exit the application? (y/n)");
                if (Console.ReadLine().ToUpperInvariant() == "Y")
                    break;
    
                continue;
            }
    
            // input validation : number, anything, number
            var values = input.Split(',');
            if (values.Length != 3 || !Regex.IsMatch(values[0], @"\d+") || !Regex.IsMatch(values[2], @"\d+"))
            {
                Console.WriteLine("Invalid input");
                continue;
            }
    
            // save save to the file
            File.AppendAllText(filePath, string.Join(",", values) + Environment.NewLine);
            Console.WriteLine("The values has been inserted into the csv.");
    
        } // rince and repeat
    }
