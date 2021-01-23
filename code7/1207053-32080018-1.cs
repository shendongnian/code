	bool isSent;
	SendEmail(BuildEmailBody(transaction, myHomeInformation),subjectLine, out isSent);
    if (isSent)
	{
		BOAssistant.WriteLine                 
	}
	 
...
	private static bool SendEmail(string emailBody, string emailSubject, out bool isSent)
     {
        //This is the method that will create the email for you
        Email email = new Email();
        email.To.Add("POvermyer@TandT.com");
        email.Subject = emailSubject;
        email.Body = emailBody;
        email.Send();
		isSent = true;
    }
