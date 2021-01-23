    while ((line = sentencesFile.ReadLine()) != null)
    {
        string SentenceFileString = line;  // can be removed
        string keyWords = line.Substring(0, line.IndexOf(' '));
        string sentence = line.Substring(line.IndexOf(' ') + 1);
        string testOutput = keyWords + sentence;
    }
