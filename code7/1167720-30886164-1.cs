    //Set up the object to serialise
	var testObject = new TestClass();
	testObject.list = new List<ListItem>();
	testObject.list.Add(new ListItem());
	
	var serializer = new System.Xml.Serialization.XmlSerializer(typeof(TestClass));
	StringWriter sw = new StringWriter();
	XmlWriter writer = XmlWriter.Create(sw);
	serializer.Serialize(writer, testObject);
	var xml = sww.ToString();
