        var result = companies
            .Where(c => !c.Coverage_status.Contains("drop"))
            .Select(n => new
            {
                FSTick = string.Format("{0}-{1}", n.Ticker, csvValues.Where(v => v.Exchange.Contains(n.Exchange)).Select(v => v.Lookup).FirstOrDefault())
            });
