	internal sealed class FacebookValidationRequest
	{
	    [UrlEncodeAttribute("access_token")]
	    public String AccessToken { get; set; }
	    [UrlEncodeAttribute("method")]
	    public String Method { get; set; }
	    [UrlEncodeAttribute("format")]
	    public String Format { get; set; }
	    [UrlEncodeAttribute("pretty")]
	    public Int32 Pretty { get; set; }
	    [UrlEncodeAttribute("suppress_http_code")]
	    public Int32 SuppressHttpCode { get; set; }
	    [UrlEncodeAttribute("debug")]
	    public string Debug { get; set; }
		public fbReq[] Batch { get; set; }
	    [UrlEncodeAttribute("batch")]
	    public String BatchString
        {
            get
            {
                // put your json serialization code here to return
                // the contents of Batch as json string.
            }
        }
	}
