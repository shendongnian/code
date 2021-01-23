    var results = db.EntryDetails
      .GroupBy(ed => ed.EntryKey)
      .ToList()
      .Select(ek => new List<string>()
        {
          string.Join(",", ek.Select(gb => gb.DetailName).ToList()),
          string.Join(",", ek.Select(gb => gb.DetailValue).ToList()),
        });
      .SelectMany(ed => ed)
      .ToList();
         
