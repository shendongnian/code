    public async Task SendMail(string AddTo, string Addcc = null, string Subject, string Message)
    {
    	var myMessage = new SendGrid.SendGridMessage();
    	myMessage.AddTo(AddTo);
    	if(AddCc != null)
    	{
    		myMessage.AddCc(Addcc);
    	}
    	myMessage.From = new MailAddress("noreply@noreply.se");
    	myMessage.Subject = Subject;
    	myMessage.Html = Message;
    
    	var credentials = new NetworkCredential(
    	   ConfigurationManager.AppSettings["mailAccount"],
    	   ConfigurationManager.AppSettings["mailPassword"]
    	   );
    	//Some validation code
    }
