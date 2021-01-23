    protected override void Render(HtmlTextWriter writer)
    {
    	if (this.Exception == null)
    	{
    		try
    		{
    			base.Render(writer);
    		}
    		catch (Exception ex)
    		{
    			this.Exception = ex;
    		}
    	}
    
    	if (this.Exception != null)
    	{
    		writer.BeginRender();
    		MRenderingManager.HandleRenderingException(writer, this.Exception, this.BaseTypeName, this);
    		writer.EndRender();
    	}
    }
