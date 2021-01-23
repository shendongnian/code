	static public void DeserializeFromXML ()
	{
        // changed to be a list of employees
		List<Employee> employees = null;
	
		// added
		MyWrapper wrapper = null;
		string path = "test.xml";
		// changed type to MyWrapper
		XmlSerializer serializer = new XmlSerializer (typeof(MyWrapper));
		StreamReader reader = new StreamReader(path);
		// changed type to MyWrapper
		wrapper = (MyWrapper)serializer.Deserialize(reader);
		reader.Close();
		employees = wrapper.Items;
	}
