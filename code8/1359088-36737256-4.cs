	string folderpath = Application.StartupPath + "\\settings";
	string appSettingsFilename = "testsettings2";
	if (!Directory.Exists(folderpath))
		Directory.CreateDirectory(folderpath);
	string filepath = folderpath + "\\" + appSettingsFilename + ".xml";
	NodeList nodes = new NodeList();
	XmlSerializer serializer = new XmlSerializer(typeof(NodeList));
	TextWriter configWriteFileStream = new StreamWriter(filepath);
	nodes.Nodes = new Test[2] {
		new Test() { Name = "Tom", Age=30},
		new Test() { Name = "John", Age=35}
	};
	serializer.Serialize(configWriteFileStream, nodes);
	configWriteFileStream.Close();
