    private void TextAlignCenter(String Line)
	{
		String CenterLine = String.Empty;
		if (Line.Length > 36)
		{
			for (int i = 0; i < Line.Length; i += 36)
			{
				if ((i + 36) < Line.Length)
					TextAlignCenter(Line.Substring(i, 36));
				else
					TextAlignCenter(Line.Substring(i));
			}
		}
		else
		{
			Int32 CountLineSpaces = (36 - Line.Length) / 2;
			for (int i = 0; i < CountLineSpaces; i++)
			{
				CenterLine += (Char)32;
			}
			CenterLine += Line + Environment.NewLine;
		}
		Console.Write(CenterLine);
	}
