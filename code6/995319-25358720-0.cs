		Regex regex = new Regex(".*form id=\"mainform\".* action=\"(.+?)\" .*");
		var lines = File.ReadAllLines(selected_path);
		foreach (string line in lines)
		{
			Match match = regex.Match(line);
			if (match.Success)
			{
				string toReplace = match.Groups[1].Value;
				lines[count] = lines[count].Replace(toReplace, Form_action);
			}
			count++;
		}
		File.WriteAllLines(selected_path, lines);
