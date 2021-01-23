    string fileName = "Q317664.xml";
	string filePath = Path.Combine (Android.OS.Environment.ExternalStorageDirectory.ToString (), fileName);
	// Check if your xml file has already been extracted.
	if (!File.Exists(filePath))
	{
		using (BinaryReader br = new BinaryReader(Assets.Open(fileName)))
        {
			using (BinaryWriter bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
			{
				byte[] buffer = new byte[2048];
				int len = 0;
				while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
				{
					bw.Write (buffer, 0, len);
				}
			}
		}
	}
    // Operate on the external file
    var xml = XDocument.Load(filePath);
    var node = xml.Descendants("Book").FirstOrDefault(cd => cd.Attribute("Id").Value == "1");
    node.SetAttributeValue("ISBN", "new");
    xml.Save("Q317664.xml");
