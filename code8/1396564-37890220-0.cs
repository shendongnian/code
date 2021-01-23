    using System.Net;
    using System.Net.Mail;
    
    using (SmtpClient client = new SmtpClient("yourserver"))
    {
        client.Credential = new NetworkCredential();
        MailMessage message = new MailMessage();
        message.To.Add("targetAddress");
        message.From = new MailAddress("from addresss");
        message.Subject = "blah blah";
        message.Body = "body text.  this can be html if you want";
        message.IsBodyHtml = true; //set this to true if the body is html
    
        client.Send(message);
    }
