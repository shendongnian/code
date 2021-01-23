    _entityContext.Statistics.
      .GroupBy(
          // Define the key for the GroupBy to be Type and the Day
          s => new { s.Type, s.Date.Year, s.Date.Month, s.Date.Day},
          // Reduce each group to just the key and the sum of its Count values
          (key, ss) => new { key, count = ss.Sum(s => s.Count) }
      );
