    var utcNow = DateTime.UtcNow; //example DateTime
    if (sortedDict.ContainsKey(utcNow))
    {
        foreach (double listItem in sortedDict[utcNow])
        {
            //manipulate listItem here
        }
    }
    
