    public string ToSubscriptFormula(string input)
    {
    	var characters = input.ToCharArray();
    	const int distance = '₀' - '0';    // distance of subscript from digit
    	for (var i = 0; i < characters.Length; i++)
    	{
    		if(char.IsDigit(characters[i]))
    		{
    			characters[i] = (char) (characters[i] + distance);
    		}
    	}
    	return new string(characters);
    }
