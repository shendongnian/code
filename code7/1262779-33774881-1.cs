    static class ColorExtension
    {
    	public static Color DrawingColor(ConsoleColor color)
    	{
    		switch (color) {
    			case ConsoleColor.Black:
    
    				return color.Black;
    			case ConsoleColor.Blue:
    
    				return color.Blue;
    			case ConsoleColor.Cyan:
    
    				return color.Cyan;
    			case ConsoleColor.DarkBlue:
    
    				return color.DarkBlue;
    			case ConsoleColor.DarkGray:
    
    				return color.DarkGray;
    			case ConsoleColor.DarkGreen:
    
    				return color.DarkGreen;
    			case ConsoleColor.DarkMagenta:
    
    				return color.DarkMagenta;
    			case ConsoleColor.DarkRed:
    
    				return color.DarkRed;
    			case ConsoleColor.DarkYellow:
    
    				return color.FromArgb(255, 128, 128, 0);
    			case ConsoleColor.Gray:
    
    				return color.Gray;
    			case ConsoleColor.Green:
    
    				return color.Green;
    			case ConsoleColor.Magenta:
    
    				return color.Magenta;
    			case ConsoleColor.Red:
    
    				return color.Red;
    			case ConsoleColor.White:
    
    				return color.White;
    			default:
    				return color.Yellow;
    		}
    	}
    }
