    [HttpPost]
    [Route("api/createmessage")]
    public void CreateMessage(string fileId)
    {
    	DataContainer container = new DataContainer();
    	container.SendQueueMessage(fileId);
    }
