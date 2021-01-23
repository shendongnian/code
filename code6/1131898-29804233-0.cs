    public static void MergeXml()
    {
        var xdoc1 = XDocument.Load(@"c:\temp\test.xml");
        var xdoc2 = XDocument.Load(@"c:\temp\test2.xml");
        var d1Targets = xdoc1.Descendants("third");
        var d2Selection = xdoc2.Descendants("third").ToList();
        Func<XElement, XElement, string, bool> attributeMatches = (x, y, a) =>
            x.Attribute(a).Value == y.Attribute(a).Value;
        Func<IEnumerable<XElement>, XElement, bool> hasMatchingValue = (ys, x) =>
            // remove && if matching "a" should cause replacement.
            ys.Any(d => attributeMatches(d, x, "a") && attributeMatches(d, x, "b"));
        foreach (var e in d1Targets)
        {
            var fromD2 = d2Selection.Find(x => attributeMatches(x, e, "id"));
            if (fromD2 != null)
            {
                d2Selection.Remove(fromD2);
                var dest = e.Descendants("value");
                dest.LastOrDefault()
                    .AddAfterSelf(fromD2.Descendants("value").Where(x => !hasMatchingValue(dest, x)));
            }
        };
        if (d2Selection.Count > 0)
            d1Targets.LastOrDefault().AddAfterSelf(d2Selection);
            
        xdoc1.Save(@"c:\temp\merged.xml");
    }
