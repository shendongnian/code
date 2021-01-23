    protected void SendMail()
            {
                MailMessage msg = new MailMessage();
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                try
                {
                    msg.Subject = "Add Subject";
                    msg.Body = "Add Email Body Part";
                    msg.From = new MailAddress("Valid Email Address");
                    msg.To.Add("Valid Email Address");
                    msg.IsBodyHtml = true;
                    client.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential basicauthenticationinfo = new System.Net.NetworkCredential("Valid Email Address", "Password");
                    client.Port = int.Parse("587");
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicauthenticationinfo;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
