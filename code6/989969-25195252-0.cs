    foreach (string sentence in allSentencesList)
    {
        string processedString = sentence;
        foreach (string entity in entityList) 
            processedString = processedString.Replace(entity, (entity + "/" + "TYPE"));
        processedSentencesList.Add(processedString); 
    }
