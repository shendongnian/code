	var isValid = true;
	if (lines.Length == 1)
	{
		// must be tab delimited list of numbers
		isValid = lines[0].Split('\t').All(x => x.All(y => Char.IsDigit(y)));
	}
	else if (lines.Length > 1)
	{
		// each line must contain a digit sequence only
		foreach (var line in lines)
		{
			isValid = line.All(z => Char.IsDigit(z));
			if (!isValid)
				break;
		}
	}
