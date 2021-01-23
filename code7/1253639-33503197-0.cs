    static string ReplaceRanges(string original, IEnumerable<Range> ranges)
    {
        var result = new StringBuilder(original.Length);
        
        int index = 0;
        
        foreach (var range in ranges)
        {
            result.Append(original, index, range.Start - index);
            
            result.Append(range.Replacement);
            
            index = range.Start + range.Length;
        }
        
        result.Append(original, index, original.Length - index);
        
        return result.ToString();
    }
