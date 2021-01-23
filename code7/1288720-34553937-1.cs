	System.Xml.Serialization.XmlSerializer serializer
		= new System.Xml.Serialization.XmlSerializer(typeof(test2));
	var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//tester.txt";
	using (System.IO.FileStream file = System.IO.File.Create(path))
	{
		serializer.Serialize(file, tester);
		file.Flush();
	}
