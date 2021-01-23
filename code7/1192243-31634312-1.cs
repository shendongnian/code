	if (!string.IsNullOrEmpty(text))
	{
		File.WriteAllText(resourcePath, text);
	}
	else
	{
		MessageBox.Show("The Batch file is empty");
	}
