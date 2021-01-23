	string xcontent = @"<?xml version='1.0' ?>..."; //replace ... with xml content
    //i decided to not post entire content of xml due to clarity of code
	
	XDocument xdoc = XDocument.Parse(xcontent);
	var data = xdoc.Descendants("Folder")
					.Select(x=> new
                        {
							FolderName = x.Element("Folder_name").Value,
							Files = x.Descendants("File")
                             .Select(a=>
                                 Tuple.Create(
                                   a.Element("File_name").Value,
                                   a.Element("File_size_in_bytes").Value)
                              ).ToList()
						})
					.SelectMany(x=>x.Files.
                       Select(y=> new
                         {
                            FolderName =x.FolderName,
                            FileName = y.Item1,
                            FileSize=y.Item2
                         }))
					.ToList();
