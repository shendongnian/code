    private List<int> test()
    {
        var intResults = new List<int>();
        var file = File.ReadLines("blah");
        foreach (var line in file)
        {
           var lineSplit = line.Split(
                new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
             foreach (var item in lineSplit)
             {
                 var result = 0;
                 if (int.TryParse(item, out result))
                     intResults.Add(result); 
             }
        }
        return intResults;
    }
