    using (MailMessage message = new MailMessage("from@my.com", "t0@my.com"))
    {
        message.CC.Add("cc@my.com");
        message.IsBodyHtml = true;
        message.Subject = "Test subject";
        message.Body = "Test Body";
        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 25;
        client.Credentials = new NetworkCredential("yourEmail", "Password");
        client.EnableSsl = true;
        client.UseDefaultCredentials = false;
        client.Send(message);
    }
