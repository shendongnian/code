    var phrases = new[] { "I am good", "He is best", "They are poor", "Mostly they are average", "All are very nice", "Not so good", };
    var lookup = phrases
        .Select((phrase, index) =>
            new
            {
                phrase,
                index,
                // Take into account that there are also tabs and other space-like chars, so it may not split some strings as intended
                words = phrase.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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
                result.phrases.Select(phrase => $"{phrase.index}='{phrase.phrase}'")));
    }
