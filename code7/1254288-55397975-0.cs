    public Task SendEmailAsync( EmailInfo email, string smtpServer, int smtpPort )
    {
    	using( var client = new SmtpClient( smtpServer, smtpPort ) )
        using( var msg = CreateMailMessageFromEmailInfo( email ) )
            return client.SendMailAsync( msg );
    }
