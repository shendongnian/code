    Dictionary<string, string> columnDict = new Dictionary<string, string>
    for (int i = 0; i < headers.Length; i++)
    {
        columnDict.Add(headers[i], prefix + (i + 1));
    }
    
