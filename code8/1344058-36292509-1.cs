    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Border Border
    {
    	get { return __border; }
    	set
    	{
    		if (value != null)
    		{
    			value = value.Clone();
    			value.DefaultVisible = false;
    		}
    		__border = value;
    	}
    }
