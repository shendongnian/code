    public static void SendEmail(string to, string toName, string body, string attachment)
    {
        var fromAddress = new MailAddress("Your Gemail Address", "Sender Project System Name");
        var toAddress = new MailAddress(to, toName);
        var att = new Attachment(HttpContext.Current.Server.MapPath(attachment));
        const string fromPassword = "Your pass";
        const string subject = "Your subject string";
        string body = body;
        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            message.Attachments.Add(att);
            smtp.Send(message);
        }
    }
