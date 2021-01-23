    var keywords = new string[] { "dropp", "Repla", "Intl" };
    
    var TickList = Companies
        .Join(Equity_issues, c => c.Ticker, e => e.Ticker, (c, e) => new { c, e })
        .Where(ce => ce.e.Primary_equity.Equals('N')
                     && keywords.All(v => !ce.c.Coverage_status.Contains(v)))
        .Select(ce => new 
         {
            LocalTick = ce.e.Local_ticker.Trim(),
            Exchange = ce.e.Exchange_code.Contains("HKSE")
                       ? "HK"
                       : (ce.e.Exchange_code.Contains("NSDQ")
                         ? "NASDQ"
                         : ce.e.Exchange_code),
            Ticker = ce.c.Ticker.Trim()
         })
        .ToList();
