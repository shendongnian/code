    Console.WriteLine("Type in several Integers:");
    string input = System.Console.ReadLine();
    List<int> numbers = null;
    if(!string.IsNullOrWhiteSpace(input))
    {
        string[] splittedLine = input.Split(' ');
        if(splittedLine != null && splittedLine.Length != 0)
        {
            foreach (var item in splittedLine)
            {
                int tmpNumber;
                if(int.TryParse(item, out tmpNumber))
                {
                    if (numbers == null) numbers = new List<int>();
                    numbers.Add(tmpNumber);
                }                            
            }
        }
    }
    else
    {
        // TODO: info for user
    }
    
    if(numbers != null)
    {
        Console.WriteLine("Min: {0}", numbers.Min());
        Console.WriteLine("Max: {0}", numbers.Max());
    }
    else
    {
        // TODO: info for user
    }
    Console.Read();
