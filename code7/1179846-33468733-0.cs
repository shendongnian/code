                string to = "yo@yo.com";
                string from = "help@help.com";
                MailMessage message = new MailMessage(from, to);
                message.Subject = "Using the new SMTP client.";
                message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
                SmtpClient client = new SmtpClient("mail.privateemail.com");
                    
                client.Credentials = new System.Net.NetworkCredential("username", "pass");
                client.Port = 587;
                client.EnableSsl = true;
    
                try
                {
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}",
                                ex.ToString());
                }
