    public Task SendAsync(IdentityMessage message)
            {
                //SmtpClient client = new SmtpClient();
                //return client.SendMailAsync(ConfigurationManager.AppSettings["SupportEmailAddr"],
                //                            message.Destination,
                //                            message.Subject,
                //                            message.Body);
    
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                //client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("mailName@gmail.com", "mailPassword");
    
                return client.SendMailAsync("mailName@gmail.com", message.Destination, message.Subject, message.Body);
            }
