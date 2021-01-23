    var phrases = new[] { "I am good", "He is best", "They are poor", "Mostly they are average", "All are very nice", "Not so\tgood \t", };
    var lookup = phrases
        .Select((phrase, index) =>
            new
            {
                phrase,
                index,
                words = phrase.Split((Char[])null, StringSplitOptions.RemoveEmptyEntries)
            })
        .SelectMany(item =>
            item
                .words
                .Select(word =>
                    new
                    {
                        word,
                        item.index,
                        item.phrase
                    }))
        .ToLookup(
            keySelector: item => item.word,
            elementSelector: item => new { item.phrase, item.index });
    var wordsToSearch = new[] { "good", "best", "nice" };
    var searchResults = wordsToSearch
        .Select(word =>
            new
            {
                word,
                phrases = lookup[word].ToArray()
            });
    foreach (var result in searchResults)
    {
        Console.WriteLine(
            "Word '{0}' can be found in phrases : {1}",
            result.word,
            String.Join(
                ", ",
                result
                    .phrases
                    .Select(phrase => 
                        String.Format("{0}='{1}'", phrase.index, phrase.phrase))));
    }      
