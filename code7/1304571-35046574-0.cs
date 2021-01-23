    IDictionary<string, string> wordDict = new Dictionary<string, string>();
    wordDict[wordsToFind.Text] = wordsToReplace.Text;
    string textToReplace = article.Text;
    foreach (KeyValuePair<string, string> entry in wordDict)
    {
        textToReplace = Regex.Replace(textToReplace, entry.Key, entry.Value, RegexOptions.IgnoreCase);
    }
