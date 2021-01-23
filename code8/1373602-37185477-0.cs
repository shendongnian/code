    string parts = new StringReader(@"C:\input.txt").ReadToEnd();
	string[] lines = parts.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
	StringBuilder sb = new StringBuilder();
	List<string> dates = new List<string>();
	for (int i = 0; i < lines.Length; i++)
	{
		string[] data = lines[i].Split(new string[] { "," }, StringSplitOptions.None);
		dates.Add(data[1]);
	}
	var datesSorted = dates.OrderBy(x => DateTime.ParseExact(x, "dd/MM/yyyy", null));
	foreach (string s in datesSorted)
	{
		sb.AppendLine(s + "<br />");
	}
	Label1.Text = sb.ToString();
