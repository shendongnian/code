	public static bool SetCacheSourceToTable(this ZipArchive xlsxZip, FileInfo destinationFileInfo, string tablename, int cacheSourceNumber = 1)
	{
		var cacheFound = false;
		var cacheName = String.Format("pivotCacheDefinition{0}.xml", cacheSourceNumber);
		using (var copiedzip = new ZipArchive(destinationFileInfo.Open(FileMode.Create, FileAccess.ReadWrite), ZipArchiveMode.Update))
		{
			//Go though each file in the zip one by one and copy over to the new file - entries need to be in order
			xlsxZip.Entries.ToList().ForEach(entry =>
			{
				var newentry = copiedzip.CreateEntry(entry.FullName);
				var newstream = newentry.Open();
				var orgstream = entry.Open();
				//Copy all other files except the cache def we are after
				if (entry.Name != cacheName)
				{
					orgstream.CopyTo(newstream);
					cacheFound = true;
				}
				else
				{
					//Load the xml document to manipulate
					var xdoc = new XmlDocument();
					xdoc.Load(orgstream);
					//Get reference to the worksheet xml for proper namespace
					var nsm = new XmlNamespaceManager(xdoc.NameTable);
					nsm.AddNamespace("default", xdoc.DocumentElement.NamespaceURI);
					//get the source
					var worksheetSource = xdoc.SelectSingleNode("/default:pivotCacheDefinition/default:cacheSource/default:worksheetSource", nsm);
					//Clear the attributes
					var att = worksheetSource.Attributes["ref"];
					worksheetSource.Attributes.Remove(att);
					att = worksheetSource.Attributes["sheet"];
					worksheetSource.Attributes.Remove(att);
					//Create the new attribute for table
					att = xdoc.CreateAttribute("name");
					att.Value = tablename;
					worksheetSource.Attributes.Append(att);
					xdoc.Save(newstream);
				}
				orgstream.Close();
				newstream.Flush();
				newstream.Close();
			});
		}
		return cacheFound;
	}
