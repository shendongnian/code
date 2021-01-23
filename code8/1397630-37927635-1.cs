    string json = File.ReadAllText("input.json");
    XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "root");
    XmlNode city = doc.SelectSingleNode("root/state/city");
    if (city != null)
    {
        string[] nodeNames = { "property1", "property2" };
        List<XmlNode> unwantedNodes = city
            .ChildNodes.Cast<XmlNode>()
            .Where(node => !nodeNames.Contains(node.Name))
            .ToList();
        unwantedNodes.ForEach(node => city.RemoveChild(node));
    }
    doc.Save("output.xml");
