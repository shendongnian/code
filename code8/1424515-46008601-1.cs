	var xmlOverrides = new XmlAttributeOverrides();
	var xmlAttribs = new XmlAttributes();	
	xmlAttribs.XmlType = new XmlTypeAttribute("TableOfItemTableDisplayMode");
	xmlOverrides.Add(typeof(Table<ItemTable.DisplayMode>), xmlAttribs);
	xmlAttribs = new XmlAttributes();
	xmlAttribs.XmlType = new XmlTypeAttribute("TableOfEffectiveItemPermissionTableDisplayMode");
	xmlOverrides.Add(typeof(Table<EffectiveItemPermissionTable.DisplayMode>), xmlAttribs);
	System.Xml.Serialization.XmlSerializer lSerializer =
		new System.Xml.Serialization.XmlSerializer(typeof(UISettings), xmlOverrides);
