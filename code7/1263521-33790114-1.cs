    var results = db.EntryDetails
      .GroupBy(ed => ed.EntryKey)
      .ToList()
      .Select(ek => new List<List<string>>()
        {
          ek.Select(gb => gb.DetailName).ToList(),
          ek.Select(gb => gb.DetailValue).ToList()
        });
      .SelectMany(ed => ed)
      .ToList();
         
