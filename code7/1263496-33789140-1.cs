    var shockValues = (from s in ctx.Shocks
                       where s.ID == id
                       select s)
                      .AsEnumerable()
                      .OrderBy(s => DateTime.ParseExact(s.MonthName, "MMM", CultureInfo.InvariantCulture).Month)
                      .Select(s => new 
                                   {
                                       val = s.MonthName + "=" + s.ShockValue
                                   });
