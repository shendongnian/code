     XmlTextReader xmlReader = new XmlTextReader("d:\\product.xml");
     while (xmlReader.Read())
        {
	switch (xmlReader.NodeType)
	{
		case XmlNodeType.Element:
			listBox1.Items.Add("<" + xmlReader.Name + ">");
			break;
		case XmlNodeType.Text:
			listBox1.Items.Add(xmlReader.Value);
			break;
		case XmlNodeType.EndElement:
			listBox1.Items.Add("");
			break;
	}
     }
 
       
