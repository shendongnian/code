    public void AssignIndexes(XElement element, string prefix, int index)
    {
        string value = prefix + index;
        element.SetAttributeValue("index", value);
        value += "."; // As the prefix for all children
        int subindex = 1;
        foreach (var child in element.Elements())
        {
            AssignIndexes(child, value, subindex++);
        }
    }
    public void AssignIndexesToChildren(XElement element)
    {
        int subindex = 1;
        foreach (var child in element.Elements())
        {
            AssignIndexes(child, "", subindex++);
        }
    }
