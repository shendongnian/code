	var xmlOverrides = new XmlAttributeOverrides();
	var xmlAttribs = new XmlAttributes();	
	xmlAttribs.XmlType = new XmlTypeAttribute("TableOfItemTableDisplayModes");
	xmlOverrides.Add(typeof(Table<ItemTable.DisplayModes>), xmlAttribs);
	xmlAttribs = new XmlAttributes();
	xmlAttribs.XmlType = new XmlTypeAttribute("TableOfEffectiveItemPermissionTableDisplayModes");
	xmlOverrides.Add(typeof(Table<EffectiveItemPermissionTable.DisplayModes>), xmlAttribs);
	System.Xml.Serialization.XmlSerializer lSerializer =
		new System.Xml.Serialization.XmlSerializer(typeof(UISettings), xmlOverrides);
