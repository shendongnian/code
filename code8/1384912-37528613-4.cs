     List<string> csvLines = new List<string>
        {
            "NASDQ,O,",
            "OTC,O,",
            "NYSE,N,",
            "TSE,T,"
        };
        var csvValues = csvLines
        .Select(l => new
        {
            Exchange = l.Split(',').First(),
            Lookup = l.Split(',').Skip(1).First()
        });
        List<Company> companies = new List<Company>
        {
            new Company { Coverage_status = "aaa", Ticker = "123", Exchange = "NASDQ"},
            new Company { Coverage_status = "1521drop422", Ticker = "1251223", Exchange = "aaaaaaaa"},
            new Company { Coverage_status = "f2hdjjd", Ticker = "15525221123", Exchange = "TSE"}
        };
        var result = companies
            .Where(c => !c.Coverage_status.Contains("drop"))
            .Select(n => new
            {
                FSTick = string.Format("{0}-{1}", n.Ticker,
                    csvValues
                        .Where(v => v.Exchange.Contains(n.Exchange))
                        .Select(v => v.Lookup).FirstOrDefault())
            });
        foreach (var r in result)
            Console.WriteLine(r.FSTick);
