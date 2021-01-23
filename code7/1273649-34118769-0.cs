    public void DrawEmptyTriangle( char symbol, char padSymbol, int triangleBase)
    {
    	// heuristics - this is because of the 2nd line
    	int alignment = triangleBase - 3;
    	int half = triangleBase / 2 + 1;
    
    	// top and bottom line are different from the others,
    	// so it is easier to generate the separately
    	string top = symbol.ToString ( ).PadLeft ( half, padSymbol).PadRight ( triangleBase, padSymbol);
    	// if this is new to you - Enumerable.Repeat will generate a sequence of n character elements
    	// string.Join will make a string inserting, in this case, a space between them
    	string bottom = string.Join ( " ", Enumerable.Repeat ( 'x', half ) );
    
    	Console.WriteLine ( top );
    	for ( int index = 1; index < triangleBase; index+=2 )
    	{
    		string line =
    			string.Format ( "{0}{1}{0}", symbol, new string ( padSymbol, index ) )
    			.PadLeft ( alignment, padSymbol )
    			.PadRight ( alignment, padSymbol );
    		alignment++;
    		Console.WriteLine ( line );
    	}
    	Console.WriteLine ( bottom );
    }
