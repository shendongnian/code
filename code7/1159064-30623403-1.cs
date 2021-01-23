    public string SendGmailMessage(string toAddress, string fromAddress, string ccAddress, string subject, string body)
    {
        MailMessage message = new MailMessage();
        SmtpClient smtpClient = new SmtpClient();
        string msg = string.Empty;
        try
        {
            MailAddress emailFrom = new MailAddress(fromAddress);
            message.From = emailFrom;
            message.To.Add(toAddress);
            if (!string.IsNullOrEmpty(ccAddress))
    	{
                message.CC.Add(ccAddress);
    	}
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;
            smtpClient.Host = "smtp.gmail.com"; 
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;  //Add this line
            smtpClient.Credentials = new System.Net.NetworkCredential("GMAILUSERNAME", "GMAILPASSWORD");
     
            smtpClient.Send(message);
            msg = "Message Sent";
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        return msg;
    }
