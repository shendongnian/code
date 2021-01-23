	void Main()
	{
		m_dict = new SortedDictionary<int, StringBuilder>();
		
		AddTextAt(1,40, "first");
		AddTextAt(2,40, "xx");
		AddTextAt(0,10, "second");
		AddTextAt(4,5, "third");
		AddTextAt(1,15, "four");
		
		GetStringFromDictionary().Dump();
	}
	
	// Define other methods and classes here
	SortedDictionary<int, StringBuilder> m_dict;
	
	/// <summary>
	/// This will emulate writting to the console, where you can set the row/column and put your text there.
	/// It's done by having Dictionary(int,StringBuilder) that will use to store our data, and eventually, 
	/// when we need the string iterate over it and build our final representation.
	/// </summary>
	/// <param name="row"></param>
	/// <param name="column"></param>
	/// <param name="text"></param>
	private void AddTextAt(int row, int column, string text)
	{
	StringBuilder sb;
	
	// NB: The following will initialize the string builder !!
	// Dictionary doesn't have an entry for this row, add it and all the ones before it
	if (!m_dict.TryGetValue(row, out sb))
	{
			int start = m_dict.Keys.Any() ? m_dict.Keys.Last() +1 : 0;
		for (int i = start ; i <= row; i++)
		{
			m_dict.Add(i, null);
		}
	} 
	
	int leftPad = column + text.Length;
	// If dictionary doesn't have a value for this row, just create a StringBuilder with as many
	// columns as left padding, and then the text
	if (sb == null)
	{
		sb = new StringBuilder(text.PadLeft(leftPad));
		m_dict[row] = sb;
	}
	// If it does have a value:
	else
	{
		// If the new string is to be to the "right" of the current text, append with proper padding
		// (column - current string builder length) and the text
		int currrentSbLength = sb.ToString().Length;
		if (column >= currrentSbLength)
		{
			leftPad = column - currrentSbLength + text.Length;
			sb.Append(text.PadLeft(leftPad));
		}
		// otherwise, text goes on the "left", create a new string builder with padding and text, and 
		// append the older one at the end (with proper padding?)
		else
		{
			m_dict[row] = new StringBuilder(  text.PadLeft(leftPad)
											+ sb.ToString().Substring(leftPad) );
		}
	}
	}
	
	/// <summary>
	/// Concatenates all the strings from the private dictionary, to get a representation of the final string.
	/// </summary>
	/// <returns></returns>
	private string GetStringFromDictionary()
	{
	var sb = new StringBuilder();
	foreach (var k in m_dict.Keys)
	{
			if (m_dict[k]!=null)
			sb.AppendLine(m_dict[k].ToString());
			else
				sb.AppendLine();
	}
	return sb.ToString();
	}
