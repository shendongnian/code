	private string GetTimeFromFile(string fileName, int searchIndex)
	{
		string pattern = string.Format("^n:{0}\s.+\spts_time:([\d.]+)\s", searchIndex);
		Regex re = new Regex(pattern);
		using (var file = File.OpenText(fileName))
		{
			string line;
			while ((line = file.ReadLine()) != null)
			{
				var m = re.Match(line);
				if (m.Success)
					return m.Groups[1];
			}
		}
		return null;
	}
