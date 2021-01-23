    using (MailMessage mm = new MailMessage("info@mydomain.com", email))
                {
                    mm.Subject = "Account Activation";
                    string body = "Hello " + name.Trim();
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "mydomain.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("info@mydomain.com", "mypassword");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 25;
                    smtp.Send(mm);
            }
