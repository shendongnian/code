    [WebMethod]
	public static void GetFullActivityDescription(Int32 id)
	{
		mHeader.InnerHtml = "<h1>Test</h1>";
        mBody.InnerHtml = id + "";
	}
