    foreach (var attr in doc.Descendants()
                            .SelectMany(d => d.Attributes())
                            .Where(a => a.Name.Namespace == ns))
    {
       attr.Parent.Add(new XAttribute(attr.Name.LocalName, attr.Value));
       attr.Remove();
    }
