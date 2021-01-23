    group s by new {s.ApplicationName, s.Type } into g
    select new ElmahError 
           {
               ApplicationName = g.Key,
               Type = g.Key,
               TotalErrors = g.Count() //If you have such property
               ErrorMessage = f.First().Errormessage //This will display only first 
                                              //error out of all (Consider checking for nulls)
            };
