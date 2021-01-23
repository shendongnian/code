	var newFile = Regex.Replace(file, @"(\d{1,2}\/\d{1,2}\/\d{4})", m =>
	{
		string matchText = m.Groups[0].ToString();
		DateTime parsedDate;
		if (DateTime.TryParse(matchText.Trim(), out parsedDate))
		{
			return parsedDate.ToString("MM/dd/yyyy");
		}
		else
		{
			return matchText;
		}
	});
    File.WriteAllText("C:\\\\Users\\hacknj\\Desktop\\TestFile.csv", newFile);
