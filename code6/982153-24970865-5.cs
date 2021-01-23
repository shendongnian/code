    var smtp = new SmtpClient();
    try
    {
        var toEmails = mailMessage.To.ToList();
        var bccEmails = mailMessage.Bcc.ToList();
    	
    	var taskMails = toEmails.Select(email => 
    	{
    		var message = new MailMessage
    		{
    			To = email
    		};
    		
    		smtp.SendMailAsync(message);
    	};
    	
    	await Task.WhenAll(taskEmails);
     }
     catch (Exception ex)
     {
       Logger.Error(ex);
     }
