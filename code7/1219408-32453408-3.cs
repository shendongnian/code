	public async Task PollingAsync()
	{
		if (Session["init"] == null) //so the sessionID is not changing on every request
			Session.Add("init", 0);
		NotificationQueue queue =
						  NotificationQueue.getInstance(HttpContext.Session.SessionID);
		while (queue.GetSize() == 0)
			await Task.Delay(200);
			
		var responseObj = queue.getNextQueueElement();
		Response.Write(new JavaScriptSerializer().Serialize(responseObj));
	}
	
