    public static bool PositionVisibleIs(RichTextBox rtb, TextPointer pos)
    {
    	try
    	{
    		// Rectangle around the character to check
    		Rect r = pos.GetCharacterRect(LogicalDirection.Forward);
    
    		// Upper left corner of the rectangle ...
    		Point upperLeftCorner = r.Location;
    
    		HitTestResult result = VisualTreeHelper.HitTest(rtb, upperLeftCorner);
    
    		// ... is visible?
    		if (result != null)
    			return true;
    		else
    			return false;
    	}
    }
