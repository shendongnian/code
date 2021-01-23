	if (SendEmail(BuildEmailBody(transaction, myHomeInformation),subjectLine))
	{
		BOAssistant.WriteLine                 
	}
	 
...
	private static bool SendEmail(string emailBody, string emailSubject)
     {
        //This is the method that will create the email for you
        Email email = new Email();
        email.To.Add("POvermyer@TandT.com");
        email.Subject = emailSubject;
        email.Body = emailBody;
        try{
        email.Send();
        } catch(e) { return false; }
		return true;
    }
	
