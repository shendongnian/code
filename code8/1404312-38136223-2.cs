    public IEnumerable<Word> GetSortedByMatches(string keyword, Word[] words)
    {
        var result = new List<Word>(
            words.Where(word => word.Name.StartsWith(keyword, true)) //<-- ignoreCase
            .OrderBy(word => word.Name));
        result.AddRange(words.Except(result).OrderBy(word => word.Name));
        return result;
    } 
