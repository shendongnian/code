There is a standard SmtpClient in C#.
	var client = new SmtpClient(host, port);
	client.EnableSsl = ssl;
	client.UseDefaultCredentials = false;
	client.Credentials = new NetworkCredential(email, password);
	var message = new MailMessage();
	message.From = new MailAddress(fromAddress);
	message.To.Add(toAddress);
	message.Subject = subject;
	var contentType = new ContentType("text/html");
	var alternateView = AlternateView.CreateAlternateViewFromString(content, contentType);
	message.AlternateViews.Add(alternateView);
	client.Send(message);
