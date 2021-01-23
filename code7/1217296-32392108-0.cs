	private static String TextAlignCenter(String Line)
    {
		int len = 36; // avoid magic numbers
		StringBuilder b = new StringBuilder(); 
        String CenterLine = String.Empty;
        for (int i = 0; i < Line.Length; i += len)
        {
            if ((i + len) < Line.Length)
				b.AppendLine(Line.Substring(i, len));                        
            else
			{
				CenterLine = Line.Substring(i);
				int CountLineSpaces = (len - CenterLine.Length) / 2;	
                // new string(' ', CountLineSpaces) replicates ' '	CountLineSpaces times
				CenterLine = new string(' ', CountLineSpaces) + CenterLine;						
				b.Append(CenterLine); 
			}
        }
        
		Console.WriteLine(b.ToString());
        return b.ToString();
    }
