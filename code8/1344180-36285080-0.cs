     MailMessage msg = new MailMessage("YourEmail@gmail.com", "DestinationEmail@something.com");
         
            msg.Subject = message.Subject;
            
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString("Message Content here as HTML", null, MediaTypeNames.Text.Html));
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32( 587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("YourEmail@gmail.com", "YourPassword");
            smtpClient.EnableSsl = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                        System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                        System.Security.Cryptography.X509Certificates.X509Chain chain,
                        System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
            smtpClient.Credentials = credentials;
    smtpClient.Send(msg);
