    using (var context = new algoventurelab_db1Context())
    {
          // Get 1 year back only Thursday
          var oneYearEarlier = DateTime.Now.AddYears(-1);
          // This will get all dates in context one year earlier.
          var query1 = (from c in context.Daily25Data
                       where c.Date > oneYearEarlier
                       select c).ToList();
          //this will filter only thurdays
          var query = from c in query1
                      where c.Date.DayOfWeek == DayOfWeek.Thursday
                      select c).ToList();
    
          Console.WriteLine(query);
    }
