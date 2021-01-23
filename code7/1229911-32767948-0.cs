    Control parent = your_panel;
    Point pt = your_point;
    // Uncomment if your point is in screen coordinates
    // pt = parent.PointToClient(pt);
    Control child = parent.GetChildAtPoint(pt);
    if (child != null)
    {
    	// There is some control, but it might not be the one you are searching for.
    
    	// Uncomment if you are searching for a direct child of your panel
    	// while (child.Parent != parent) child = child.Parent;
    
    	// Use other criterias. For instance:
    	var userControl = child as UserControl;
    	if (userControl != null)
    	{
    		// There you go.
    	}
    }
