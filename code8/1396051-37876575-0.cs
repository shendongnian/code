    [__DynamicallyInvokable]
    protected override void Dispose(bool disposing)
    {
    	try	{
    		this.PurgeBuffers(disposing);
    	}
    	finally	{
    		try	{
    			if (disposing && !this._leaveOpen && this._stream != null) {
    				this._stream.Close();
    			}
    		}
    		finally	{
    			this._stream = null;
    			try	{
    				if (this.deflater != null)	{
    					this.deflater.Dispose();
    				}
    			}
    			finally	{
    				this.deflater = null;
    				base.Dispose(disposing);
    			}
    		}
    	}
    }
