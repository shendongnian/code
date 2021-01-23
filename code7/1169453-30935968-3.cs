    public static List<string> IsSMTPRequestValid(this SmtpGatewayRequest smtpRequest)
    {
    	List<string> invalidEmails = new List<string>();
        SmtpRequestContent content = smtpRequest.Body as SmtpRequestContent;
		foreach (var email in content.EmailCC)
		{
			if (!IsEmail(email))
			{
				invalidEmails.Add(email);
			}
		}
		return invalidEmails;
    }
