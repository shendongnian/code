    var result = list.Select(str =>
            str
                .Split(',')
                .Select(v => v.Trim()).ToArray())
        .Select(x =>
            new
            {
                Name = x[0],
                Value = x[1],
                Image = x[2],
                CatId = Convert.ToInt32(x[3]),
                Id = Convert.ToInt32(x[4])
            })
        .GroupBy(x => x.CatId)
        .Select(x => new StuffType
        {
            Category = DefineRange(x.Key),
            dailyStuffs = x.Select(y => new DailyStuffs
            {
                CategoryId = x.Key, //Maybe instead here you want to put the Id?
                ConvertedName = y.Value, //I am mapping from Value to ConvertedName. Is this correct?
                StuffImage = y.Image,
                StuffName = y.Name
            }).ToList()
        }).ToList();
