    document.Root.DescendantsAndSelf("Warranties")
        .SelectMany(n =>
            n.Elements("Warranty")
                .GroupBy(g => g.Element("ServiceLevelDescription").Value)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g))
        .Remove();  
