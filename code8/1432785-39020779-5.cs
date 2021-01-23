    xml.Root.Descendants("Country")
        .Select(element => new 
        {
            Id = (string) element.Attribute("ID").Value,
            NonEmptyWork = element.Descendants("Work")
                                  .Count(w => !string.IsNullOrEmpty(w.Value)),
            NonEmptyHome = element.Descendants("Home")
                                  .Count(w => !string.IsNullOrEmpty(w.Value))
        })
        .GroupBy(item => item.Id)
        .Select(g => new
        { 
            Id = g.Key, 
            NonEmptyWorkAmount = g.Sum(item => item.NonEmptyWork), 
            NonEmptyHomeAmount = g.Sum(item => item.NonEmptyHome)
        })
        .OrderBy(item => item.Id)
        .ToList();
