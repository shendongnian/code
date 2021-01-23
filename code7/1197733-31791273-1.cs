    var cleared = ListOfThings
      .GroupBy(x => x.ID)
      .Select(chunk => {
         // Side effect: writing to log while selecting
         if (chunk.Skip(1).Any()) 
           Log.Append(Logger.Type.Error, "Conflicts with another", "N/A", chunk.Key);
         // if there're duplicates by Id take the 1st one
         return chunk.First();
       })
      .ToList();
