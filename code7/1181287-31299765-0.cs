    var grouped = codes.Select(x => x.Split('.'))
                       .Select(x => new
                       {
                           Prefix = int.Parse(x.First()),
                           Subcode = int.Parse(x.Last())
                       })
                       .GroupBy(k => k.Prefix)
                       .Select(g => new
                       {
                           Prefix = g.Key,
                           Subcodes = g.Select(s => s.Subcode)
                       })
                       .Select(x =>
                           x.Prefix +
                           (x.Subcodes.Count() > 1 ? string.Format("({0})", string.Join(",", x.Subcodes)) : string.Empty)
                       ).ToArray();
