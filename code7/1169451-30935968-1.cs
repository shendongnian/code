    public static string IsSMTPRequestValid(this SmtpGatewayRequest smtpRequest)
    {
    	StringBuilder invalidEmails = new StringBuilder();
        SmtpRequestContent content = smtpRequest.Body as SmtpRequestContent;
    	content.EmailCC.Where(email => !IsEmail(email))
    		.ForEach(n =>
    		{
    			invalidEmails.AppendLine(n)
    		});
        return invalidEmails.ToString();
    }
    
