    List<newClass> result = oldObject.Menu.Layouts
        .SelectMany(l => l.OneOrMoreCollection
            .Select(c => new newClass
            {
                id = c.Id,
                variation = c.Variation,
                description = c.Description,
                size = l.Size
            }))
            .ToList(); 
