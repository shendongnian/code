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
    
        // now we can use the full path to get the document
   
        // Will get all the numbers in the file
        var numbers = File.ReadAllText(path)
                          .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                          .Select(t => Convert.ToInt32(t))
                          .ToList();
        // Will skip the first number wich is equal to 25, and for each following number will create a new instance of the Resistors class, 
        // giving the first paramater with te first item of the numbers collection (25) and in second paramater the number to pow
        var resistors = numbers.Skip(1)
                               .Select(t => new Resistors(numbers[0], t))
                               .ToList();  
        
        Console.WriteLine("Res#\tDissipitation\tPassed");
        foreach (var item in resistors)
        {
            Console.WriteLine("{0:d}\t{1:N}", resistors.IndexOf(item) + 1, item.GetPower());
        }
        Console.ReadKey();     
    }
