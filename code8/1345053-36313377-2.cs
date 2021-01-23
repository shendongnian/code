    using (var context = new algoventurelab_db1Context())
    {
          // Go one year back from current date
          var startDate = DateTime.Today.AddYears(-1);
          // This will get all dates in context greater than start date.
          var query1 = (from c in context.Daily25Data
                       where c.Date >= startDate
                       select c).AsEnumerable();
          //this will filter only thurdays
          var query = from c in query1
                      where c.Date.DayOfWeek == DayOfWeek.Thursday
                      select c).ToList();
    
          Console.WriteLine(query);
    }
