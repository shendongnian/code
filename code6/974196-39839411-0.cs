    public void SendEmail(MyInternalSystemEmailMessage email)
    {
    	var mailMessage = new System.Net.Mail.MailMessage();
    	mailMessage.From = new System.Net.Mail.MailAddress(email.FromAddress);
    	mailMessage.To.Add(email.ToRecipients);
    	mailMessage.ReplyToList.Add(email.FromAddress);
    	mailMessage.Subject = email.Subject;
    	mailMessage.Body = email.Body;
    	mailMessage.IsBodyHtml = email.IsHtml;
    
    	foreach (System.Net.Mail.Attachment attachment in email.Attachments)
    	{
    		mailMessage.Attachments.Add(attachment);
    	}
    
    	var mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mailMessage);
    
    	var gmailMessage = new Google.Apis.Gmail.v1.Data.Message {
    		Raw = Encode(mimeMessage.ToString())
    	};
    
    	Google.Apis.Gmail.v1.UsersResource.MessagesResource.SendRequest request = service.Users.Messages.Send(gmailMessage, ServiceEmail);
    
    	request.Execute();
    }
    
    public static string Encode(string text)
    {
    	byte[] bytes = System.Text.Encoding.UTF8.GetBytes(text);
    
    	return System.Convert.ToBase64String(bytes)
    		.Replace('+', '-')
    		.Replace('/', '_')
    		.Replace("=", "");
    }
