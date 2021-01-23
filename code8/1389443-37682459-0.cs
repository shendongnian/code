    private static IEnumerable<XElement> GroupElements(IEnumerable<XElement> elements)
    {
        var elementsByName = elements.GroupBy(x => x.Name);
        foreach (var grouping in elementsByName)
        {
            var transformed = grouping.Select(e =>
                new XElement(e.Name,
                    GroupElements(e.Elements()),
                    e.Attributes(),
                    e.Nodes().OfType<XText>()));
            
            if (grouping.Count() == 1)
            {
                yield return transformed.Single();
            }
            else
            {
                var groupName = grouping.Key + "s";
                yield return new XElement(groupName, transformed);
            }
        }
    }
