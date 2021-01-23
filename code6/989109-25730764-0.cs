                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                msg.To.Add("RecipientMail");
                msg.From = new MailAddress("sender@gmail.com", "gmailpassword", System.Text.Encoding.UTF8);
                msg.Subject = "UR SUBJECT";
                msg.SubjectEncoding = System.Text.Encoding.UTF8;
                msg.Body = "UR BODY";
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = false;
    
                //Aquí es donde se hace lo especial
                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential("sender@gmail.com", "gmailpassword");
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
                try
                {
                    client.Send(msg);
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
