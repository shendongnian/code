    public static IEnumerable<XElement> EnumerateGroup(this XElement source, string groupName)
    {
        return source.Elements()
            .Where(element => Regex.IsMatch(element.Name.LocalName, "^" + groupName + "[a-z0-9]*$"));
    }
