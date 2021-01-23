    public static void SendEmail(string subject, string body)
    {
    	using (var client = new SmtpClient(utilities.EmailHost, 25))
    	using (var message = new MailMessage()
    	{
    		From = new MailAddress(utilities.FromEmail),
    		Subject = subject,
    		Body = body
    	})
    	{
    		System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment("your attachment file");
            mail.Attachments.Add(attachment);
         	message.To.Add(address);
    		client.Send(message);
    	};
    }
