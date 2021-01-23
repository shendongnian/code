    public string GetLetterAllDuplicates(string text)
    {
       // check if the text was provided
       if (string.IsNullOrEmpty(letter))
          throw new ArgumentException("You must provide a text.", "text");
    
       // if it is lower than 2 chars, return the first one
       // I'm not sure if it is what you want, but let's consider it.
       if (text.Length <= 2)
          return text[0];
    
       // find the first letter
       var letters = text.GroupBy(c => c) // group by char
                         // in the group, count how many occurrences each letter has
                         .Select(x => { Letter = x.Key, Total = x.Count() }) 
                          // get only the occurrences that has more than 1.. (you can change this parameter)
                         .Where(x => Total > 1) 
                         // get it as array
                         .ToArray();
      var result = string.Join(letters, "");
    
      return result ;
    }
