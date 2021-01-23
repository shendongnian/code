	internal sealed class FacebookValidationRequest : UrlEncodeSerializable
	{
	    [UrlEncodeAttribute(access_token)]
	    public String AccessToken { get; set; }
	    [UrlEncodeAttribute(method)]
	    public String Method { get; set; }
	    [UrlEncodeAttribute(format)]
	    public String Format { get; set; }
	    [UrlEncodeAttribute(pretty)]
	    public Int32 Pretty { get; set; }
	    [UrlEncodeAttribute(suppress_http_code)]
	    public Int32 SuppressHttpCode { get; set; }
	    [UrlEncodeAttribute(debug)]
	    public string Debug { get; set; }
	
	    [UrlEncodeAttribute(batch)]
	    public String BatchString { get; private set; }
	    public fbReq[] Batch { get; set; }
        public void PrepareAttributes()
        {
            // put your json serialization code here, and store the serialized
            // contents of the array "Batch" in the string "BatchString".
        }
	}
