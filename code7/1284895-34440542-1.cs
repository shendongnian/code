	string xmlString = "<1>text1</1><27>text27</27><3>text3</3>";
	xmlString = "<Root>" + xmlString.Replace("<", "<o").Replace("<o/", "</o") + "</Root>"; //wrap to make this having single root, o is put to force the tagName started with known letter (comment edit suggested by Mr. chwarr)
	string key = "";
	List<KeyValuePair<string,string>> kvpList = new List<KeyValuePair<string,string>>(); //assuming the result is in the KVP format
	using (XmlReader xmlReader = XmlReader.Create(new StringReader(xmlString))){
		bool firstElement = true;
		while (xmlReader.Read()) {
			if (firstElement) { //throwing away root
				firstElement = false;
				continue;
			}
			if (xmlReader.NodeType == XmlNodeType.Element) {
				key = xmlReader.Name.Substring(1); //cut of "o"
			} else if (xmlReader.NodeType == XmlNodeType.Text) {
				kvpList.Add(new KeyValuePair<string,string>(key, xmlReader.Value));
			}
		}
	}
