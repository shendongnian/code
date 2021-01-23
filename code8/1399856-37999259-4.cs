    var items = "abcdefffghhijjk";
    var badChars = new[] { 'f', 'h' };
    var indexCieling = items.Count() - 1;
    var badCharIndexes = items.Select((item, index) => 
        {
            if (index >= indexCieling)
            {
                return null as int?;
            }
            else
            {
                if (item == items.ElementAt(index + 1) && badChars.Contains(item))
                {
                    return index as int?;
                }
                else
                {
                    return null as int?;
                }
            }
        });
    var doesAdjacentDupeExist = badCharIndexes.Any(x => x.HasValue);
