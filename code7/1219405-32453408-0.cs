	public async Task PollingAsync()
	{
		if (Session["init"] == null) //so the sessionID is not changing on every request
			Session.Add("init", 0);
		NotificationQueue queue = NotificationQueue.getInstance(HttpContext.Session.SessionID);
		object responseObj = null;
		responseObj = await Task.Run(() =>
		{
			while (queue.getSize() == 0)
				Thread.Sleep(200);
			return queue.getNextQueueElement(); //behind this is queue.Dequeue();
		});
		Response.Write(new JavaScriptSerializer().Serialize(responseObj));
	}
	
