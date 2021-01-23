    private void DoTheThing(int? userInput1, int? userInput2, int valuePassedIn)
    {
        // what actually goes wrong: an argument "userInput1" is null
        if (null == userInput1)
          throw new ArgumentNullException("userInput1"); 
        else if (null == userInput2)
          throw new ArgumentNullException("userInput2"); // ...or is userInput2 is null
    
        var queryResult = executeSomeQuery();
    
        // what went wrong? We don't expect that null can be returned
        // so the operation "executeSomeQuery" failed. 
        if (null == queryResult) 
          throw new InvalidOperationException(String.Format("Query bla-bla-bla returned null when bla-bla-bla expected", ...));   
         
        // We're good, so do the thing
        // Note that's there's no "arrow-head antipattern": 
        // we're not within any "if" or "else" scope 
    }
