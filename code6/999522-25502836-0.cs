    using System.Net;
    using System.Net.Mail; 
    string to = strSidMail;
    string from = "rajeeshmenoth@wordpress.com";
   
    MailMessage message = new MailMessage(from, to);
    message.Subject = txt_subject.text;
    message.Body = mailbody;
    message.BodyEncoding = Encoding.UTF8;
    message.IsBodyHtml = true;
    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
    System.Net.NetworkCredential basicCredential1 = new
    System.Net.NetworkCredential("yourgmail id", "Password");
    client.EnableSsl = true;
    client.UseDefaultCredentials = false;
    client.Credentials = basicCredential1;   
    try
    {
    client.Send(message);
    }
    catch (Exception ex)
    {
    throw ex;
    }
