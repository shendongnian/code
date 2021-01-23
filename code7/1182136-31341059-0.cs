  	public HttpRequestMessage Request
	{
		get
		{
			if (this._controllerContext == null)
			{
				return null;
			}
			return this._controllerContext.Request;
		}
	}
