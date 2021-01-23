    try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("e_mail_from");
            mail.To.Add(new MailAddress("lecturer_email"));
            mail.Subject = "Plan approval";
            mail.Body = "I request my plan approval";
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("your_mail", "your_password");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(mail);
            mail.Dispose();
        }
        catch (Exception ex)
        {
            //...
        }
        finally
        {
            //...
        }
