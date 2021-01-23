    public static string IsSMTPRequestValid(this SmtpGatewayRequest smtpRequest)
    {
    	StringBuilder invalidEmails = new StringBuilder();
        SmtpRequestContent content = smtpRequest.Body as SmtpRequestContent;
		foreach (var email in content.EmailCC)
		{
			if (!IsEmail(email))
			{
				invalidEmails.AppendLine(email);
			}
		}
		return invalidEmails.ToString();
    }
