    var vowels = var vowels = new Regex("[aeiou]", RegexOptions.IgnoreCase);
    var lineCount = 0;
    var wordCount = 0;
    foreach (var line in lines)
    {
        bool hasThreeVowelWord = false;
        // Get words
        var words = line.Split(' ');
        foreach (var word in words)
        {
            var vowelCount = vowels.Matches(word).Count;
            if (vowelCount == 3)
            {
                wordCount++; 
                hasThreeVowelWord = true;
            }
        }
        if (hasThreeVowelWord) { lineCount++; }
    } 
