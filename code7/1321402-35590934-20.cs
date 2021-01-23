	int k = 0;
	foreach (Match m in Regex.Matches(sInput, "#START#(.*?)#END#", RegexOptions.Singleline | RegexOptions.Compiled))
	{
		k++;
		switch (k)
		{
			case 1:
				var1 = m.Groups[1].Value;
				break;
			case 2:
				//var2...
				break;
		}
		foreach (var line in m.Groups[1].Value.Split('\n'))
		{
			switch (iLineCount)
			{
            }
        }
	}
