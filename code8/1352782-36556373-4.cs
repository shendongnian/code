	bool[] exclude = new bool[Text.Length];
	for (int i = 0; i < Indexes.Count; i++)
	{
		if (Indexes[i] < exclude.Length)
		{
			exclude[Indexes[i]] = true;
		}
	}
	StringBuilder sb = new StringBuilder(Text.Length);
	for (int i = 0; i < Text.Length; i++)
	{
		if (!exclude[i])
		{
			sb.Append(Text[i]);
		}
	}
	return sb.ToString();
