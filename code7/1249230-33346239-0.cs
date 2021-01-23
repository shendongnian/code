    public static List<string> Function(List<string> inputList, int max)
    {
        var inputIntegers = inputList
            .Select(z => int.Parse(z))
            .ToList();
    
        var maxAuthorizedValue = inputIntegers
            .OrderBy(z => z)
            .Take(max)
            .Last();
    
        return inputIntegers
            .Select(z => z <= maxAuthorizedValue ? z.ToString() : "n")
            .ToList();
    }
    
    public static void Main(string[] args)
    {
        List<string> in_list = new List<string> { "2", "3", "4", "6", "1", "7" };
    
        var res = Function(in_list, 3);
    
        Console.Read();
    }
