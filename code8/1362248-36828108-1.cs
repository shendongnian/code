    Console.WriteLine("Type in several Integers:");
    string input = System.Console.ReadLine();
    List<int> numbers = null;
    if(!string.IsNullOrWhiteSpace(input)) // Check if any character has been entered by user
    {
        string[] splittedLine = input.Split(' '); // Split entered string
        if(splittedLine != null && splittedLine.Length != 0) // Check if array is not null and has at least one element
        {
            foreach (var item in splittedLine)
            {
                int tmpNumber;
                if(int.TryParse(item, out tmpNumber)) // Parse string to integer with check
                {
                    if (numbers == null) numbers = new List<int>(); // If is at least one integer - create list with numbers
                    numbers.Add(tmpNumber); // Add number to list of int
                }                            
            }
        }
    }
    else
    {
        // TODO: info for user
    }
    
    if(numbers != null) // Check if list of int is not null
    {
        Console.WriteLine("Min: {0}", numbers.Min()); // Get min value from numbers using LINQ
        Console.WriteLine("Max: {0}", numbers.Max()); // Get max value from numbers using LINQ
    }
    else
    {
        // TODO: info for user
    }
    Console.Read();
