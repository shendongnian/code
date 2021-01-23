    IEnumerable<string[]> ParseXml()
    {
        var templateList = new List<string> { "ID", "Name", "Address", "Phone", "Email", "Gender" };
        using (var xmlReader = XmlReader.Create("test.xml"))
        {
            yield return templateList.ToArray(); // header
            xmlReader.MoveToContent();
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element
                    && xmlReader.Name != "TRXC") // exclude TRXC
                {
                    string[] result = new string[templateList.Count];
                    for (int i = 0; i < templateList.Count; i++)
                    {
                        if (xmlReader.MoveToAttribute(templateList[i]))
                            result[i] = xmlReader.Value;
                        else
                            result[i] = "NULL";
                    }
                    yield return result; // each row
                }
            }
        }
    }
