	public string TextSpeak(string text)
	{
		return File.ReadAllLines(@"H:\SECourseowork\textwords.csv")
			.Select(line => line.Split(','))
			.Aggregate(text, (a, x) => a.Replace(x[0], String.Format("{0}<{1}>", x[0], x[1])));
	}
	
	
