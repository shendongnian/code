    /// <summary>
    /// An extension from the sealed StringBuilder class that saves 
    /// a color with a StringBuilder !
    /// </summary>
    public static class StringBuilderExt
    {
    	private static readonly Dictionary<StringBuilder, Color> colors = new Dictionary<StringBuilder, Color>();
	    
	    public static void SetColor(this StringBuilder builder, Color color)
	    {
	    	colors[builder] = color;
	    }
	    
	    public static Color GetColor(this StringBuilder builder)
	    {
		    if(colors.ContainsKey(builder))
		    {
			    return colors[builder];
		    }
		    
		    return Color.Black;
	   }
    }
