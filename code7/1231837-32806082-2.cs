    string GetNameByPattern(string s)
    {
        const string pattern_length = 6; //SnnEnn
    	for (int i = 0; i < s.Length - pattern_length; i++)
    	{
    		string part = s.SubString(i, pattern_length);
    		
    		if (part[0] == 'S' && part[3] == 'N') //candidat
    			if (Char.IsDigit(part[1]) && Char.IsDigit(part[2]) && Char.IsDigit(part[4]) && Char.IsDigit(part[5])) 
    				return s.SubString(0, i + pattern_length);
    	}
    	
    	return "";
    }
