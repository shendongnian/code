    private String getFile(String uri)
		{		
			Uri uriFile = new Uri(uri);
			String fileName = Path.GetFileName(uri);
			List<String> fileData = new List<String>();
			
			// Reads all the code lines of a file
			fileData = readCodeLines(uriFile);
			
			String tempPath = @"c:\temp\";
		   
			try
			{
				if (!Directory.Exists(tempPath))
				{
					Directory.CreateDirectory(tempPath);
				}
				File.WriteAllLines(tempPath, fileData);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Could not find the Temp folder" + " " + tempPath);
			}
			return fileName;
		}
