    public void Save(string fileName = null)
	{
		AssignDefaultSettingsFilePathIfEmpty(ref fileName);
		File.WriteAllText(fileName, (new JavaScriptSerializer()).Serialize(this));
	}
	private void AssignDefaultSettingsFilePathIfEmpty(ref string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			fileName = DEFAULT_FILENAME;
		}
	}
