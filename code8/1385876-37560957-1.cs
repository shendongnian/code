    [TestFixture]
    public class Tester
    {
    
    	[Test]
    	public async Task TestSendTestMail()
    	{
    		// Arrange
    
    		// Act
    		await EbayProxy.Instance.SendTestMail();
    
    		// Assert
    	}
    }
    
    public async Task SendTestMail()
    {
    	MailMessage mail = new MailMessage();
    	mail.From = new MailAddress(_mailFrom);
    	mail.To.Add(_mailTo);
    
    	mail.Subject = "Test Mail Subject Async";
    
    	mail.Body = "Test Mail Body";
    
    	mail.IsBodyHtml = true;
    
    	SmtpClient smtp = new SmtpClient(_smtpClient, Convert.ToInt32(_smtpPort));
    	smtp.EnableSsl = true;
    	smtp.Credentials = new NetworkCredential(_mailFrom, _mailFromPassword);
    
    	await smtp.SendMailAsync(mail); // Not sending mail :(
    }
