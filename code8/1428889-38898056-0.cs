     public void SendEmail(string recipient, string subject, string text)
        {
            //The smtp and port can be adjusted, deppending on the sender account
            SmtpClient client = new SmtpClient(_smtpHostServer);
            client.Port = _smtpHostPort;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            try
            {
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential(_serveraddress, _serverpassword);
                client.EnableSsl = true;
                client.Credentials = credentials;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Creates a new message
            try {
                var mail = new MailMessage(_serveraddress.Trim(), recipient.Trim());
                mail.Subject = subject;
                mail.Body = text;
                client.Send(mail);
            }
            //Failing to deliver the message or to authentication will throw an exception
            catch (Exception ex){
                Console.WriteLine(ex.Message);
                throw;
            }
        }
