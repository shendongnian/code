    var templateList = new List<string> { "ID", "Name", "Address", "Phone", "Email", "Gender" };
    using (var xmlReader = XmlReader.Create("test.xml"))
    using (var csvWriter = new StreamWriter("test.csv"))
    {
        csvWriter.WriteLine("\"" + string.Join("\",\"", templateList) + "\"");
        xmlReader.MoveToContent();
        while (xmlReader.Read())
        {
            if (xmlReader.NodeType == XmlNodeType.Element
                && xmlReader.Name != "TRXC")
            {
                csvWriter.Write('"');
                for (int i = 0; i < templateList.Count; i++)
                {
                    if (xmlReader.MoveToAttribute(templateList[i]))
                        csvWriter.Write(xmlReader.Value);
                    else
                        csvWriter.Write("NULL");
                    if (i < templateList.Count - 1)
                        csvWriter.Write("\",\"");
                }
                csvWriter.WriteLine('"');
            }
        }
    }
