	string currentline = box.Lines[box.GetLineFromCharIndex(box.SelectionStart)];
	var listOfStrings = new List<string>();
	string[] splitedBox = box.Split('|');
	foreach(string sp in splitedBox)
	{
		string[] lineleft = sp.Split('\n');
		listOfStrings.Add(lineleft[lineleft.Count() - 1]);
	}
