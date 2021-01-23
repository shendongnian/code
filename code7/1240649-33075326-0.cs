       XmlReader xReader = XmlReader.Create(new StringReader(xmlNode));
    while (xReader.Read())
    {
        switch (xReader.NodeType)
        {
            case XmlNodeType.Element:
                listBox1.Items.Add("<" + xReader.Name + ">");
                break;
            case XmlNodeType.Text:
                listBox1.Items.Add(xReader.Value);
                break;
            case XmlNodeType.EndElement:
                listBox1.Items.Add("");
                break;
        }
    }
