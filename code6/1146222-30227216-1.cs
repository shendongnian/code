    mailMessage.From = new MailAddress(fromEmailAddress);
    mailMessage.Subject = "Test";
    mailMessage.Body = "Manish";
    mailMessage.IsBodyHtml = true;
    mailMessage.To.Add(new MailAddress(toEmailAddress));
    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 465);          
    smtp.EnableSsl = true;
    smtp.Credentials = new System.Net.NetworkCredential(userNAme, password);
    smtp.Send(mailMessage);
