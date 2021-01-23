    public static class RectangleFExtensions
    {
    	public static int Outcode(this RectangleF rect, PointF point)
    	{
    		int outcode = 0;
    		
    		if (rect.Width <= 0) outcode |= (int)RectOut.Left | (int)RectOut.Right;
    		if (rect.Height <= 0) outcode |= (int)RectOut.Top | (int)RectOut.Bottom;
    		if (point.Y < rect.Top) outcode |= (int)RectOut.Top;
    		if (point.Y > rect.Bottom) outcode |= (int)RectOut.Bottom;
    		if (point.X < rect.Left) outcode |= (int)RectOut.Left;
    		if (point.X > rect.Right) outcode |= (int)RectOut.Right;
    		
    		return outcode;
    	}
    }
