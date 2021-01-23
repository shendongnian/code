    private HttpPostedFileBase _postedFile;
    /// <summary>
    /// For mocking HttpPostedFile
    /// </summary>
    public HttpPostedFileBase PostedFile
    {
    	get
    	{
    		if (_postedFile != null) return _postedFile;
    		if (HttpContext.Current == null)
    		{
    			throw new InvalidOperationException("HttpContext not available");
    		}
    		return new HttpContextWrapper(HttpContext.Current).Request.Files[0];
    	}
    	set { _postedFile = value; }
    }
    [HttpPost]
    public MyResponse Upload()
    {
    	if (!ValidateInput(this.PostedFile))
    	{
    		return new MyResponse
    		{
    			Status = "Input validation failed"
    		};
    	}
    }
    private bool ValidateInput(HttpPostedFileBase file)
    {
    	if (file.ContentLength == 0)
    		return false;
    	
    	if (file.ContentType != "test")
    		return false;
    	
    	if (file.ContentLength > (1024 * 2048))
    		return false;
    
    	return true
    }
