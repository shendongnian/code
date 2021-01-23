    Enumerable.Range(1, Math.Max(a.Count, b.Count)).
      Select(x => new { 
                            x<a.Length?a[x]:null,
                            x<b.Length?b[x]:null
                      }
            ).ToArray();
