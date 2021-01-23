    private Color FindKeyColour(Dictionary<Color, List<Color>> dict, Color c)
	{
	    if (!dict.ContainsKey(c))
		{
		    //The colour is not a key
			return dict.FirstOrDefault(d => d.Value.Contains(c)).Key;
		}
		else
		{
		    //The colour passed in is a key
		    return c;
		}
	}
	
