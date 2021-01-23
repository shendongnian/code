    using (var message = new MailMessage(fromAddress, toAddress)
	{
	    Subject = subject,
		Body = body
	})
	{
	    Attachment attachment = new Attachment(filePath);
		message.Attachments.Add(attachment);
			 
		smtp.Send(message);
	}
