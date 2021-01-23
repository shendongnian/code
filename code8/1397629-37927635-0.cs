    string json = File.ReadAllText("input.json");
    XmlDocument doc = JsonConvert.DeserializeXmlNode(json, "root");
    string[] nodes = new[] { "property1", "property2", "property3" };
    XmlNode city = doc.SelectSingleNode("root/state/city");
    if (city != null)
    {
        for (int i = 0; i < city.ChildNodes.Count; i++)
        {
            if (!nodes.Contains(city.ChildNodes[i].Name))
                city.RemoveChild(city.ChildNodes[i]);
        }
    }
    doc.Save("output.xml");
