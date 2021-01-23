    public string GetLetterWithMoreOccurrences(string text)
    {
       // check if the text was provided
       if (string.IsNullOrEmpty(letter))
          throw new ArgumentException("You must provide a text.", "text");
    
       // if it is lower than 2 chars, return the first one
       // I'm not sure if it is what you want, but let's consider it.
       if (text.Length <= 2)
          return text[0];
    
       // find the first letter
       var letter = text.GroupBy(c => c) // group by char
                        .Select(x => { Letter = x.Key, Total = x.Count() }) // in the group, count how many occurrences each letter has
                        .OrderByDescending(x => x.Total) // order by the total by descending
                        .First(); // get the first one
    
      return letter;
    }
