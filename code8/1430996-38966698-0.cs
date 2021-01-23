     var mergedList = 
          FinalList.Select(x => new { 
              Date = x.Birthdate, Type = "Birthday", Value = x})
          .Concat(
              FinalList
                 .Where(x => x.Birthday != x.Anniversary) // if needed
                 .Select(x => new { 
                    Date = x.Anniversary, Type = "Anniversary", Value = x});
     // Now list have all unique dates - can group and extract any info
     var grouped = mergedList 
        .GroupBy(u => u.Date)
         .Select(grp => new { 
             Date = grp.Key, 
             ListOfNames = grp.Select(x => new {x.Value.Name, x.Type}).ToList()
          })
         .ToList();
         
  
