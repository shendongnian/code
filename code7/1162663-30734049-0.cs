    public IEnumerable<WordItem> FindWordCount(IEnumerable<string> wordlist)
    {
        var wordCount = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);
        foreach (string word in wordlist)
        {
            int count = 0;
            if(wordCount.TryGetValue(word, out count))
                count++;
            wordCount[word] = count;
        }
        foreach (var kv in wordCount)
            yield return new WordItem { Word = kv.Key, Count = kv.Value };
    }
