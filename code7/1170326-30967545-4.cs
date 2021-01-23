	foreach (XmlNode node in elemList1)
	{
        if (node.Attributes["Name"] != null)
        {
            string name = node.Attributes["Name"].Value;
            // do whatever you want with name
        }
        if (node.Attributes["Parent"] != null)
        {
            // logic when Parent attribute is present
            // node.Attributes["Parent"].Value is the value of Parent attribute
        }
        else
        {
            // logic when Parent attribute isn't present
        }
	}
