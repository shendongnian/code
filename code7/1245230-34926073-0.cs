	string exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
	string dataDir = new Uri(new Uri(exeDir), @"../../Data/").LocalPath;
	// Open the document.
	Document doc = new Document(dataDir + "SaveAsPNG.doc");
	//Create an ImageSaveOptions object to pass to the Save method
	ImageSaveOptions options = new ImageSaveOptions(SaveFormat.Png);
	options.Resolution = 160;
	// Save each page of the document as Png.
	for (int i = 0; i < doc.PageCount; i++)
	{
		options.PageIndex = i;
		doc.Save(string.Format(dataDir+i+"SaveAsPNG out.Png", i), options);
	}
