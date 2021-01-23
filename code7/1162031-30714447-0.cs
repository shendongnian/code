    int _beginIndex;
    
    public void BeginTrace(
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    { 
        _beginIndex = sourceLineNumber;
    }
    
    public void EndTrace(
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        int index = 0;
        foreach(var line in File.ReadLines(sourceFilePath))
        {
           if(index++ > _beginIndex && index <sourceLineNumber)
               Console.WriteLine(line);
        }
    }
