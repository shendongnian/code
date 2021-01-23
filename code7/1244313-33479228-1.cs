                mail.Body = message;
                try
                {
                    mail.To.Add(new MailAddress("To Address"));
                 
                }
                catch
                {
                }
                client.Credentials = new System.Net.NetworkCredential("smtp.live.com", "password");
                client.EnableSsl = true;
               
                try
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    client.Send(mail);
                    mail.To.Clear();
                }
                catch (Exception ex)
                {
                   
                }
            }
