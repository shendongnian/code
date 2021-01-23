    using( var mail = new System.Net.Mail.MailMessage() )
    {
        mail.From = new System.Net.Mail.MailAddress( fromAddress );
        mail.Subject = subject;
        mail.Body = body;               
    
        foreach( var attachment in attachments )
           mail.Attachments.Add( new Attachment( attachment ) );
        foreach( var address in toAddresses )
           mail.To.Add( address );
        using( var smtp = new System.Net.Mail.SmtpClient( smtpAddress, smtpPort ) )
        {
            smtp.EnableSsl = enableSsl;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential( authUserName, authPassword );
       
            ServicePointManager.ServerCertificateValidationCallback =
            ( sender, certificate, chain, sslPolicyErrors ) => true;
    
            smtp.Send( mail );
        }
    }
