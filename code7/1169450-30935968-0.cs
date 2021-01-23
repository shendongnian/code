    public static string IsSMTPRequestValid(this SmtpGatewayRequest smtpRequest)
    {
    	StringBuilder result = new StringBuilder();
        SmtpRequestContent content = smtpRequest.Body as SmtpRequestContent;
        content.EmailCC.Where(email => !IsEmail(email))
    		.ForEach(n =>
    		{
    			result.AppendLine(n)
    		});
		return result.ToString();
    }
