    protected virtual void Page_Init(object sender, EventArgs e)
    {
    	if (CommonConfig.SuppressRenderingExceptions)
    	{
    		try
    		{
    			this.Initialize();
    		}
    		catch (Exception ex)
    		{
    			this.Exception = ex;
    		}
    	}
    	else
    	{
    		this.Initialize();
    	}
    }
