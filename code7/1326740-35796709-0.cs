    public async Task SaveTextAsync(string filename)
    {
    	var path = CreatePathToFile(filename);
    	ApplicationData data = new ApplicationData();
    	ApplicationVersion version = new ApplicationVersion();
    	version.SoftwareVersion = "test version";
    	data.ApplicationVersion = version;
    	XmlSerializer writer =
    		new XmlSerializer(typeof(ApplicationData));
    	System.IO.FileStream file = System.IO.File.Create(path);
    	writer.Serialize(file, data);
    	file.Close();
    
    }
    
    public async Task<ApplicationData> LoadTextAsync(string filename)
    {
    	var path = CreatePathToFile(filename);
    	
    	ApplicationData records = null;
    	await Task.Run(() =>
    	{
    		// Create an instance of the XmlSerializer specifying type and namespace.
    		XmlSerializer serializer = new XmlSerializer(typeof(ApplicationData));
    
    		// A FileStream is needed to read the XML document.
    		FileStream fs = new FileStream(path, FileMode.Open);
    		XmlReader reader = XmlReader.Create(fs);
    
    		// Use the Deserialize method to restore the object's state.
    		records = (ApplicationData)serializer.Deserialize(reader);
    		fs.Close();
    	});
    	return records;
    }
