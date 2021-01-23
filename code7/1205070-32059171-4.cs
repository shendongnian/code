	[Route("api/messages/{messageId:guid}")]
	public async Task<IHttpActionResult> Post(Guid messageId, CreateMessageAttachments model)
	{
		// Access to all properties in your post model
		Trace.WriteLine(model.Foo);
		Trace.WriteLine(model.Bar);
		foreach (var attachment in model.Attachments)
		{
			// Do what you need to with the bytes from the uploaded attachments
			var bytes = attachment.GetByteArray();
		}
	    return Ok();
	}
