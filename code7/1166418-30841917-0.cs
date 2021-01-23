    var nodeAttributes = parentNodes.Select(le => le.Descendants("Node")
        .GroupBy(x => new { 
            Id = x.Attribute("id").Value, 
            Name = x.Attribute("name").Value 
        })
        .Select(g => new {
            g.Key.Id,
            g.Key.Name,
            DistinctModeCount = g.Select(x => x.Attribute("mode").Value)
                                 .Distinct()
                                 .Count()
        });
