    public HttpResponseMessage RenderImage(RenderRequest renderRequest, HttpRequestMessage request)
    {
	    var httpResponse = new HttpResponseMessage();
    	try
	    {
		    var reader = cmd.ExecuteReader();
    		while (reader.Read())
	    	{
		    	byte[] imagebytes = (byte[])reader["MyImageColumn"];
		    }
		    return httpResponse = request.CreateResponse<byte[]>(HttpStatusCode.OK, imagebytes, new ImageMediaFormatter("image/png"));
    	}
	    catch ()
	    {
		    throw;
	    }
    }
