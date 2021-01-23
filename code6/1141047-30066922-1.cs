    static void Main(string[] args)
    {
        var intCollections = new List<List<int>>();
        intCollections.Add(new List<int> { 1, 5, 3 });
        intCollections.Add(new List<int> { 7, 9 });
    
        var stringCollections = new List<List<String>>();
        stringCollections.Add(new List<String> { "a", "b" });
        stringCollections.Add(new List<String> { "c","d", "e" });
        stringCollections.Add(new List<String> { "g", "f" });
    
        //here you would have the "polymorphism", the same signature for different Lists types
        var intCombinations = GetPermutations(intCollections);
        var stringCombinations = GetPermutations(stringCollections);
    
        foreach (var result in intCombinations)
        {
            result.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();
        }
    
        Console.WriteLine();
    
        foreach (var result in stringCombinations)
        {
            result.ForEach(item => Console.Write(item + " "));
            Console.WriteLine();
        }
    
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
    
    //This would be your generic implementation, basically changing from object to T and adding <T> after method
    private static List<List<T>> GetPermutations<T>(List<List<T>> collections)
    {
        List<List<T>> permutations = new List<List<T>>();
    
        //Check if the input list has any data, else return the empty list.
        if (collections.Count <= 0)
            return permutations;
    
        //Add the values of the first set to the empty List<List<object>>
        //permutations list
        foreach (var value in collections[0])
            permutations.Add(new List<T> { value });
    
    
        /* Skip the first set of List<List<object>> collections as it was
            * already added to the permutations list, and loop through the
            * remaining sets. For each set, call the AppendValues function
            * to append each value in the set to the permuations list.
            * */
        foreach (var set in collections.Skip(1))
            permutations = AppendNewValues(permutations, set);
    
        return permutations;
    }
    
    private static List<List<T>> AppendNewValues<T>(List<List<T>> permutations, List<T> set)
    {
        //Loop through the values in the set and append them to each of the
        //list of permutations calculated so far.
        var newCombinations = from additional in set
                                from value in permutations
                                select new List<T>(value) { additional };
    
        return newCombinations.ToList();
    } 
