    using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Credentials = new System.Net.NetworkCredential("my_email_in_gmail@gmail.com", "very_very_complicated_password_with_numbers_and_signs");
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 465;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;// disable it
                    /// Now specify the credentials 
    smtpClient.Credentials = new NetworkCredential(message.From.Address, fromPassword)
    
                    await smtpClient.SendMailAsync(message);
                }
