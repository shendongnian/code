    xml.Root.Descendants("Country")
        .Select(element => new 
        {
            Id = (string)x.Attribute("ID").Value,
            EmptyWork = element.Descendants("Work")
                               .Count(w => string.IsNullOrEmpty(w.InnerText)),
            EmptyHome = element.Descendants("Home")
                               .Count(w => string.IsNullOrEmpty(w.InnerText))
        })
        .GroupBy(item => item.Id)
        .Select(g => new
        { 
            Id = g.Key, 
            EmptyWorkAmount = g.Sum(item => item.EmptyWork), 
            EmptyHomeAmount = g.Sum(item => item.EmptyHome)
        })
        .OrderBy(item => item.Id)
        .ToList();
