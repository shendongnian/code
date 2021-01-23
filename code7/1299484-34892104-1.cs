      MailMessage mail = new MailMessage("fromm@gmail.com", "toaddress@gmail.com");
                    mail.Subject = "TestEmailImportant";
                    mail.Body = "This mail is to test if this program is working";
    
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    
                    smtpClient.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = "XXXXXX@gmail.com",
                        Password = "YYYYYYYY"
                    };
    
                    smtpClient.EnableSsl = true;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                            System.Security.Cryptography.X509Certificates.X509Chain chain,
                            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
    
                    smtpClient.Send(mail);
