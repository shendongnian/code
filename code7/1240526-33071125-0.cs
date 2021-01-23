    double temporary = -1;  // temp value for checking
    List<double> results = new List<double>(); // list to store results
    
    (from articlespricehistory in dt.AsEnumerable()
     select new
     {
        articlepricehistory_cost = articlespricehistory.Field<Double>("articlepricehistory_cost")
     })
      .Select(a => a.articlepricehistory_cost)
      .ToList()
      .ForEach(cost => 
      {
          if (temporary != cost) { results.Add(cost); }
          temporary = cost;
      });
    foreach (var result in results)
    {
        Console.WriteLine(result);
    }
