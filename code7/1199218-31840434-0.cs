    IEnumerable<Rectangle> AllSquaresIn(Rectangle rect)
    {
    	for (int x = 0; i x < rect.Width; x++)
    	{
    		for (int y = 0; y < rect.Height; y++)
    		{
    			int maxLength = Math.Min(rect.Width - x, rect.Height - y);
    			for (int i = 1; i <= maxLength; i++)
    			{
    				yield return new Rectangle(x, y, x + i, y + i);
    			}
    		}
    	}
    }
