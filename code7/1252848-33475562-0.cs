    	SmtpClient sptmClient = new SmtpClient("exchange server name")
    MailMessage m = new MailMessage();
	m.To.Add(new MailAddress("Address"));
	m.From = new MailAddress("");
	m.Subject = "";
	m.Body = "";
	m.IsBodyHtml = true;
	sptmClient.Send(m);
