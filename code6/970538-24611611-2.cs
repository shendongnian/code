    private void Input_ListTokens(string filterType, string filterValue)
    {
        var filter = String.Format("{0} = \"{1}\"", filterType, filterValue);
        var result = Tokens.AsQueryable().Where(filter);
        foreach (var item in result)           
            Console.WriteLine(item);           
    }
