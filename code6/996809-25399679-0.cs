    	public static IEnumerable<string> ExtractValues(string path, char separator = ':')
		{
			if (path == null) throw new ArgumentNullException("path");
			var values = new List<string>();
			using (var sr = new StreamReader(path))
			{
				string line;
				while ((line = sr.ReadLine()) != null)
				{
					var index = line.IndexOf(separator);
					if (index >= 0)
					{
						values.Add(line.Substring(index + 1));
					}
				}
			}
			return values;
		}
