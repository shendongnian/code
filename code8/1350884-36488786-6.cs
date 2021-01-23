    public string ToSubscriptFormula(string input)
    {
    	var characters = input.ToCharArray();
    	const int difference = '₀' - '0';
    	for (var i = 0; i < characters.Length; i++)
    	{
    		if(char.IsDigit(characters[i]))
    		{
    			characters[i] = (char) (characters[i] + difference);
    		}
    	}
    	return new string(characters);
    }
