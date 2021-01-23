    using SendGridMail;
    using SendGridMail.Transport;
    
    public static void SendAccountConfirmationEmail(string recipient)
    {
        try
        {
            SendGrid mail = SendGrid.GetInstance();
            mail.From = new MailAddress(ConfigurationManager.AppSettings["APP_EMAIL"], "RC2 FIT");
            mail.AddTo(recipient);
            mail.Subject = "Testing the SendGrid Library";
            mail.Text = "Hello world!";
            
            var credentials = new NetworkCredential(ConfigurationManager.AppSettings["SENDGRID_API_USER"], ConfigurationManager.AppSettings["SENDGRID_API_KEY"]);
            var transportWeb = new Web(credentials);
            transportWeb.Deliver(mail);
        }
        catch (Exception e)
        {   
            System.Diagnostic.Debug.Writeline(e.Message);
        }
    }
