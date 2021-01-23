    public async Task SendSmtpMailAsync()
    {
    	fullHtml = (fullHtml == null ? ViewToString("~/View/Shared/_DocumentTemplate.cshtml", controllerContext, new emailModel { body = body, subject = subject }) : fullHtml);
    	messageMail.Body = fullHtml;
    	System.Net.Mail.SmtpClient smtp = smtpClient ?? new SmtpClient();
    	await smtp.SendMailAsync(messageMail);
    }
