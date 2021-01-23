    List<string> stopWordsDic = new List<string>();
    
    string stopWordsContent = System.IO.File.ReadAllText(stopWordsPath);
    string[] stopWordsSeperated = stopWordsContent.Split(Environment.NewLine);
    foreach (string stopWord in stopWordsSeperated)
    {
        stopWordsDic.Add(stopWord);
    }
