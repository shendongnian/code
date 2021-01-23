        from comp in Companies.Where(c => !c.Coverage_status.Contains("drop")).AsEnumerable()
    select new
    {
        FSTick = string.Format("{0}-{1}", comp.Ticker,
                    csvValues
                        .Where(v => v.Exchange.Contains(comp.Exchange))
                        .Select(v => v.Lookup).FirstOrDefault())
    };
