        // Collections of models having the same Date or Name.
        var dates = modelData.GroupBy(x => x.DT.Date);
        var names = modelData.GroupBy(x => x.Name);
        foreach (var modelsWithDate in dates)
        {
           var aDate = modelsWithDate.Key;
           var dateRealTrades = modelsWithDate.Where(x => x.real == 1).ToList();
           foreach (var modelsWithName in names)
           {
               var aName = modelsWithName.Key;
               var namesRealTrades = modelsWithName.ToList();
               // DO MY PROCESSING
           }
        }
