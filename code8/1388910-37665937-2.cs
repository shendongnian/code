<!-- -->
    void traverse(XElement elem)
    {
        foreach (var e in elem.Elements())
        {
            traverse(e);
        }
        var groups = elem.Elements().GroupBy(e => e.Name);
        foreach (var g in groups)
        {
            if (g.Count() > 1)
            {
                var sameNodes = g.ToList();
                sameNodes.Remove();
                elem.AddFirst(new XElement(g.Key + "s", sameNodes));
            }
        }
    }
