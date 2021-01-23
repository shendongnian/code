    public static void CompareExecutions<TObject, TParameter, TReturn>(this TObject originalSource, TObject alternateSource, IEnumerable<TParameter> parameters, Func<TObject, TParameter, TReturn> testExpression)
        where TObject : class
        where TReturn : class
    {
        var originalResults = new List<TReturn>();
        using (new Profile("Original Source"))
            foreach (var parameterSet in parameters)
                originalResults.Add(testExpression(originalSource, parameterSet));
    
        var alternateResults = new List<TReturn>();
        using (new Profile("Alternate Source"))
            foreach (var parameterSet in parameters)
                alternateResults.Add(testExpression(alternateSource, parameterSet));
    
        var comparer = new PropertyComparer<TReturn>();
        int errorCount = 0;
        for (int i = 0; i < parameters.Count(); i++)
        {
            if (!comparer.Equals(originalResults[i], alternateResults[i]))
            {
                errorCount++;
                Debug.WriteLine("^--- Mismatch for parameter {0}:\r\n\t{1}", i, string.Join("\r\n\t", parameters.ElementAt(i)));
            }
        }
    
        if (errorCount > 0)
            Assert.Fail("The results did not match for {0} items", errorCount);
    }
