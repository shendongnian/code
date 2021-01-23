	using (XmlReader reader = XmlReader.Create(xmlfile, settings))
	{
		reader.MoveToContent();
		var qn = new XmlQualifiedName(reader.LocalName, reader.NamespaceURI);
        // element test: schemas.GlobalElements.ContainsKey(qn);
        // check if there's an xsi:type attribute: reader["type", XmlSchema.InstanceNamespace] != null;
        // if exists, resolve the value of the xsi:type attribute to an XmlQualifiedName
        // type test: schemas.GlobalTypes.ContainsKey(qn);
        // if all good, keep reading; otherwise, break here after setting your error flag, etc.
	}
