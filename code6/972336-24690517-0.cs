    class Program
        {
            private static string to = "XXXXr@youHostingComapny.com";
            private static string from = "YYYYY@youHostingComapny.com";
            private static string subject = "test Mail sent By Code";
            private static string body = "Mail sent By Code";
    
            static void Main(string[] args)
            {
                try
                {
    
                    MailMessage mail = null;
    
                    using (mail = new MailMessage(new MailAddress(from), new MailAddress(to)))
                    {
    
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.To.Add("ZZZZZZZZ@gmail.com");
    
                        SmtpClient smtpMail = null;
                        using (smtpMail = new SmtpClient("HostingComapny smtp Address"))
                        {
                            smtpMail.Port = Hosting Company Port No.;
                            smtpMail.EnableSsl = false;
                            smtpMail.Credentials = new NetworkCredential("youruserName", "yourPassword");
    
                            smtpMail.UseDefaultCredentials = false;
                            // and then send the mail
                            ServicePointManager.ServerCertificateValidationCallback =
        delegate(object s, X509Certificate certificate,
                 X509Chain chain, SslPolicyErrors sslPolicyErrors)
        { return true; };
                            smtpMail.Send(mail);
                            Console.WriteLine("sent");
                            Console.ReadLine();
    
                        }
    
                    }
    
                }
                catch (Exception ex)
                {
    
                    throw ex;
                }
    
            }
    
    
        }
