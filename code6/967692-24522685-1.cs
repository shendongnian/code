    IEnumerable<Task> DoExample(string input) 
    { 
        var aResult = DoAAsync(input); 
        yield return aResult; 
        var bResult = DoBAsync(aResult.Result); 
        yield return bResult; 
        var cResult = DoCAsync(bResult.Result); 
        yield return cResult; 
        … 
    }
    … 
    Task t = Iterate(DoExample(“42”));
