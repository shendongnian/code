    private Dictionary<string, string> GetParameterDictionnary(XmlNode sectionNode)
    {
        var dictionary = new Dictionary<string,string>();
        foreach(var child in sectionNode.Children)
        {
            dictionary.Add(child.Attribute("name"), child.Attribute("value"));
        }
        return dictionary;
    }
