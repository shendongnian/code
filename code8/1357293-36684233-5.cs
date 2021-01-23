    static void Main(string[] args)
    {            
        // This line of code gets the path to the My Documents Folder
        string environment = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "\\";
        Console.WriteLine("Resistor Batch Test Analysis Program");
        Console.WriteLine("Data file must be in your Documents folder");
        Console.Write("Please enter the file name: ");
        string input = Console.ReadLine();
    
        // concatenate the path to the file name
        string path = environment + input;
            
        // Will read all lines
        var lines = File.ReadAllLines(path).ToList();
        // Will get the first line arguments and split them on the comma, you add more arguments if need, just separate them by a comma
        var firstLineArgs = lines[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    .Select(t => Convert.ToInt32(t))
                                    .ToArray();
        // Will skip the first line arguments and parse all the following numbers
        var numbers = lines.Skip(1)
                           .Select(t => Convert.ToInt32(t))
                           .ToList();
        // Will create each Resistors object with the first line arguments (25) and the actual number
        // You can do whatever you want with the second arguments (150)
        var resistors = numbers.Select(t => new Resistors(firstLineArgs[0], t))
                               .ToList();  
        
        Console.WriteLine("Res#\tDissipitation\tPassed");
        foreach (var item in resistors)
        {
            // Check if item.GetPower() is greather firstLineArgs[1] (150)
            // I don't know what you want to do if it's greater
            Console.WriteLine("{0:d}\t{1:N}", resistors.IndexOf(item) + 1, item.GetPower());
        }
        Console.ReadKey();     
    }
