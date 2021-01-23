    try
    {
        using (var client = new SmtpClient())
        {
            MailMessage mail = new MailMessage("danielohayon2014@gmail.com", (string)txtEmail.Text);
            mail.Subject = "this is a test email.";
            mail.Body = "this is my test email body";
            client.Send(mail);
        }
    
        lblError.Text = "Message sent!";
    }
    catch (Exception ex)
    {
        lblError.Text = ex.ToString();
    }
