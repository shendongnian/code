    static void Main(string[] args)
    {
        for (int i = 0; i < 100; i++)
        {
            string html = "<h1>TEST</h1>";
            Task.Factory.StartNew(() =>
            {
                using (MailMessage mail = new MailMessage("sender@domain.com", "receiver@domain.com"))
                {
                    mail.Subject = "Test";
                    mail.IsBodyHtml = true;
                    mail.Body = html;
                    using (SmtpClient client = new SmtpClient("<internal ip address>"))
                    {
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("<user name>", "<password>");
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Send(mail);
                    }
                }
            }).ContinueWith(aex => {
                if (aex.Exception != null)
                {
                    //add some logic to deal with the exception
                }
            });
        }
    }
