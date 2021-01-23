    double previousWidth;
    double previousHeight;
    
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        
        	if (previousWidth != width || previousHeight != height)
        	{
        		previousWidth = width;
        		previousHeight = height;
        	
        		if (width > height)
        		{
        			// landscape mode
        		}
        		else
        		{
        			// portrait mode
        		}	
        	}
        }
