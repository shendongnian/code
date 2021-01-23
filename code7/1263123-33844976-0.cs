        var dates = modelData.GroupBy(x => x.DT.Date);
        var names = modelData.Select(x => x.name).Distinct().ToArray();
        foreach (var date in dates)
        {
            var dateRealTrades = date.Where(x => x.real.Equals(1)).ToArray();
            var namesRealTradesLookup = dateRealTrades.ToLookup(x => x.name);
            foreach (var aName in names)
            {
                var namesRealTrades = namesRealTradesLookup[aName];
                // DO MY PROCESSING
                // var aDate = date.Key;
            }
        }
