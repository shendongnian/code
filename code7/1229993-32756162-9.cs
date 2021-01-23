	var xmlString = "<?xml version=\"1.0\" encoding=\"utf-16\"?><MyClass><Id>1</Id><Names><string>Surya</string><string>Kiran</string></Names><ClassTypes><Types><TypeId>1</TypeId><TypeName>First Name</TypeName></Types><Types><TypeId>2</TypeId><TypeName>Last Name</TypeName></Types></ClassTypes><Status>1</Status></MyClass>";
			   
	xmlString = xmlString.Replace("<ClassTypes>", "")
						.Replace("</ClassTypes>", "")
						.Replace("<Names>", "")
						.Replace("</Names>", "");
	xmlString = xmlString.Replace("<Types>", "<ClassTypes>")
				.Replace("</Types>", "</ClassTypes>")
				.Replace("<string>", "<Names>")
				.Replace("</string>", "</Names>");
	var xmlDoc = new XmlDocument();
	xmlDoc.LoadXml(xmlString);
	var xmlNode = xmlDoc.SelectNodes("//MyClass").Item(0);
	var jsonString = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlNode, Newtonsoft.Json.Formatting.Indented, true);
