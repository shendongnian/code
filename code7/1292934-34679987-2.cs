    _exchangeService = new ExchangeService(ExchangeVersion.Exchange2013_SP1);
    _exchangeService.AutodiscoverUrl(_sender);
    using email = new EmailMessage(_exchangeService)
    {
    	From = new MailAddress("customerservice@mycompany.com"),
    	Subject = subject,
    	Body = body
    })
    {
    	//System.Net.Mail.Attachment attachment;
    	//attachment = new System.Net.Mail.Attachment("your attachment file");
    	//mail.Attachments.Add(attachment);
    	message.To.Add(address);//Jess@Jess.com for example
    	client.Send(message);
    };
