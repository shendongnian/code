    void Main()
    {
        var text = "Walked. Turned back. But why? And said \"Hello world. Damn this string splitting things!\" without a shame.";
        var result = SplitText(text);
    }
    
    private static List<String> SplitText(string text)
    {
        var result = new List<string>();
        
        var sentenceEndings = new HashSet<char> { '.', '?', '!' };
        
        var startIndex = 0;
        var length = 0;
        
        var isQuote = false;
        for (var i = 0; i < text.Length; i++)
        {
            var c = text[i];
            if (c == '"' && !isQuote)
            {
                isQuote = true;
                continue;
            }
            
            if (c == '"' && isQuote)
            {
                isQuote = false;
                continue;
            }
            
            if (isQuote)
            {
                continue;
            }
            
            if (sentenceEndings.Contains(c))
            {
                length = i + 1 - startIndex;
                var part = text.Substring(startIndex, length);
                result.Add(part);
                startIndex = i + 2;
            }
        }
        return result;
    }
            
