	string folderpath = Application.StartupPath + "\\settings";
	string appSettingsFilename = "testsettings";
	if (!Directory.Exists(folderpath))
		Directory.CreateDirectory(folderpath);
	string filepath = folderpath + "\\" + appSettingsFilename + ".xml";
	DummyClass2 dummyClass2 = new DummyClass2();
	XmlSerializer serializer = new XmlSerializer(typeof(DummyClass2));
	TextWriter configWriteFileStream = new StreamWriter(filepath);
	dummyClass2.NodeList =  new TestList[2] {
		new TestList() {
			TestItem = new Test[2] { 
				new Test() { Key="Name", Value="Tom"},
				new Test() { Key="Age", Value="30"}
			}
		},
		new TestList() {
			TestItem = new Test[2] { 
				new Test() { Key="Name", Value="John"},
				new Test() { Key="Age", Value="35"}
			}
		}
	};
	serializer.Serialize(configWriteFileStream, dummyClass2);
	configWriteFileStream.Close();
