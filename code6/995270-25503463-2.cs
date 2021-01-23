	public async void test()
	{
		try
		{
			StorageFile file = await StorageFile.GetFileFromPathAsync("Filepath");
			if (file != null)
			{
				StringBuilder outputText = new StringBuilder();
				// Get basic properties
				BasicProperties basicProperties = await file.GetBasicPropertiesAsync();
				outputText.AppendLine("File size: " + basicProperties.Size + " bytes");
				outputText.AppendLine("Date modified: " + basicProperties.DateModified);
				// Specify more properties to retrieve
				string dateAccessedProperty = "System.DateAccessed";
				string fileOwnerProperty = "System.FileOwner";
				List<string> propertiesName = new List<string>();
				propertiesName.Add(dateAccessedProperty);
				propertiesName.Add(fileOwnerProperty);
				// Get the specified properties through StorageFile.Properties
				IDictionary<string, object> extraProperties = await file.Properties.RetrievePropertiesAsync(propertiesName);
				var propValue = extraProperties[dateAccessedProperty];
				if (propValue != null)
				{
					outputText.AppendLine("Date accessed: " + propValue);
				}
				propValue = extraProperties[fileOwnerProperty];
				if (propValue != null)
				{
					outputText.AppendLine("File owner: " + propValue);
				}
			}
		}
		// Handle errors with catch blocks
		catch (FileNotFoundException)
		{
			// For example, handle a file not found error
		}
	}
