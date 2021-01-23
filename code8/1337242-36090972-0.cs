    public enum RectOut
    {
    	Top = 1,
    	Right = 2,
    	Bottom = 4,
    	Left = 8,
    }
    
    public static class RectangleFExtensions
    {
    	public static int Outcode(this RectangleF rect, PointF point)
    	{
    		int outcode = 0;
    		if (rect.Contains(point))
    		{
    			if (point.Y == rect.Top) outcode |= (int)RectOut.Top;
    			if (point.Y == rect.Bottom) outcode |= (int)RectOut.Bottom;
    			if (point.X == rect.Left) outcode |= (int)RectOut.Left;
    			if (point.X == rect.Right) outcode |= (int)RectOut.Right;
    		}
    		
    		return outcode;
    	}
    }
