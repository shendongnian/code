    return xml.Root.Descendants("Country")
        .Select(element => new 
        {
            Id = (string)x.Attribute("ID").Value,
            NonEmptyWork = element.Descendants("Work")
                                  .Count(w => !string.IsNullOrEmpty(w.InnerText)),
            NonEmptyHome = element.Descendants("Home")
                                  .Count(w => !string.IsNullOrEmpty(w.InnerText))
        })
        .GroupBy(item => item.Id)
        .Select(g => new YourType
        { 
            Id = g.Key, 
            NonEmptyWorkAmount = g.Sum(item => item.NonEmptyWork), 
            NonEmptyHomeAmount = g.Sum(item => item.NonEmptyHome)
        })
        .OrderBy(item => item.Id)
        .ToList();
