    /// <summary>
    /// Returns the hyperlink that covers the given position.
    /// </summary>
    public static Hyperlink GetHyperlinkFromPosition(TextPointer pos)
    {
    	if (pos.Paragraph == null) return null;
    
    	Hyperlink hl = FindObjectFirst<Hyperlink>(pos, pos.Paragraph.ElementEnd, false);
    
    	if (hl != null && hl.ContentStart.CompareTo(pos) < 0 && hl.ContentEnd.CompareTo(pos) > 0)
    	{
    		return hl;
    	}
    
    	return null;
    }
    
    public static T FindObjectFirst<T>(TextPointer topPos, TextPointer bottomPos, bool searchBackwards) where T : DependencyObject
    {
    	if (searchBackwards)
    	{
    		TextPointer currPos = bottomPos;
    
    		while (currPos != null && currPos.CompareTo(topPos) >= 0)
    		{
    			DependencyObject depObj = currPos.GetAdjacentElement(LogicalDirection.Backward);
    
    			if (depObj is T)
    			{
    				return (T)depObj;
    			}
    
    			currPos = currPos.GetNextContextPosition(LogicalDirection.Backward);
    		}
    	}
    	else
    	{
    		TextPointer currPos = topPos;
    
    		while (currPos != null && currPos.CompareTo(bottomPos) <= 0)
    		{
    			DependencyObject depObj = currPos.GetAdjacentElement(LogicalDirection.Forward);
    
    			if (depObj is T)
    			{
    				return (T)depObj;
    			}
    
    			currPos = currPos.GetNextContextPosition(LogicalDirection.Forward);
    		}
    	}
    
    	return null;
    }
