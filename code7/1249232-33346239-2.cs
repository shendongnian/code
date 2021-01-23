    public static List<string> Function(List<string> inputList, int max)
    {
        var inputIntegers = inputList.Select(z => int.Parse(z)).ToList();
    
        var maxAuthorizedValue = inputIntegers
            .OrderBy(z => z)
            .Take(max)
            .Last();
    
        // I don't really like that kind of LINQ query (which modifies some variable
        // inside the Select projection), so a good old for loop would probably
        // be more appropriated
        int returnedItems = 0;
        return inputIntegers.Select(z =>
            {
                return (z <= maxAuthorizedValue && ++returnedItems <= max) ? z.ToString() : "n";
            }).ToList();
    }
