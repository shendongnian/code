    SmtpClient client = new SmtpClient("SMTP.GMail.com", 587)
    {
       Credentials = new System.Net.NetworkCredential("MyEmail@GMail.com","Pa55W0rd"),
       EnableSsl = true,
       DeliveryMethod = SmtpDeliveryMethod.Network
    };
        
    MailMessage message = new MailMessage();
    message.From = new MailAddress("MyEmail@GMail.com", "Shane's GMail");
    message.To.Add(new MailAddress("MyEmail@AnotherDomain.com", "Shane"));
    message.Subject = "Testing GMail SMTP";
    message.IsBodyHtml = true;
    message.Body = String.Format("<HTML><HEAD></HEAD><BODY>Testing 1, 2, 3.</BODY></HTML>");
    client.Send(message);
