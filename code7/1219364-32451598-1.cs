	[Route("api/SenderDetails")]
	[HttpPost]
	public IHttpActionResult Test(SenderDetails senderDetails)
	{
		// Here, we will have those details available, 
		// given that the deserialization succeeded.
		Debug.Writeline(senderDetails.SenderName);
	}
