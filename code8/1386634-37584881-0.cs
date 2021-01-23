    var fromAddress = new MailAddress("test@gmail.com", "Test Email");
    var toAddress = new MailAddress(MailDetails.senderMail, "");
    const string fromPassword = "password";
    string subject = "" //your subject line
    string body = "" // your body
    var smtp = new SmtpClient
    {
    Host = "smtp.gmail.com", //example
    Port = 587,
    EnableSsl = true,
    DeliveryMethod = SmtpDeliveryMethod.Network,
    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
    Timeout = 20000
    };
    using (var message = new MailMessage(fromAddress, toAddress)
    {
    Subject = subject,
    Body = body
    })
    {
     try
    {
    smtp.Send(message);
    }
    catch (Exception ex)
    {
    }
    }
