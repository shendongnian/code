    void Main()
    {
    	Int32 totalLines = 9;
    	for (Int32 i = 0; i <= totalLines; ++i)
    		Console.WriteLine(Line(i, totalLines));
    }
    
    String Line(Int32 i, Int32 totalLines)
    {
    	Int32 charCount = 2 * totalLines + 1;
    	Int32 center = charCount / 2;
    	
    	// Last line is filled completely
    	if (i == totalLines) return new String(Enumerable.Repeat('*', charCount).ToArray());
	
    	Char[] chars = Enumerable.Repeat(' ', charCount).ToArray();
	    chars[center-i] = '*';
    	chars[center+i] = '*';
    	return new String(chars);
    }
