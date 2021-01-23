    //Create Mail body
    string Emails = MailId;
    string file = Server.MapPath("~/Mail.html");
    //Generate Mail Body
    string mailbody = "Hi"+" " +Emails;
    //Whom to send email
     string to = Emails;
    //Who is sending mail
    string from = "Sender_Mail_Id";
    MailMessage msg = new MailMessage(from, to);
    msg.Subject = "Auto Response Email";
    msg.Body = mailbody;
    msg.BodyEncoding = Encoding.UTF8;
    msg.IsBodyHtml = true;
    SmtpClient client = new SmtpClient("smtp.gmail.com");
    client.UseDefaultCredentials = false;
    System.Net.NetworkCredential basicCredential = new System.Net.NetworkCredential("User_EMailId", "Password");
    client.EnableSsl = true;
    client.UseDefaultCredentials = true;
    client.Credentials = basicCredential;
