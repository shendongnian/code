    var message = new MailMessage(fromAddress, toAddress);
    message.Subject = subject;
    message.Body = body;
    message.To.Add(new MailAddress("dplatypus@att.net", "Duckbilled Platypus"));
    message.To.Add(new MailAddress("duckbill@att.net", "Platypus 2"));
    smtp.Send(message);
