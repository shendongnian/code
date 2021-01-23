    [WebMethod]
	public static void GetFullActivityDescription(Int32 id)
	{
		string data = new { title="Test", msg= id + "" };
		Response.Clear();
		Response.ContentType = "application/json; charset=utf-8";
		Response.Write(data);
		Response.End();
	}
