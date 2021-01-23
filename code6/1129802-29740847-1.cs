	string maxFolder = String.Empty;
	
	foreach(string folderName in folderNames)
	{
		if(CompareVersions(folderName.Split('_'), maxFolder.Split('_')) > 0)
		{
			maxFolder = folderName;
		}
	}
