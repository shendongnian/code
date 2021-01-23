    [System.Web.Services.WebMethod]
     public static string SendEmail()
     {
      using (MailMessage mm = new MailMessage("From", "To"))
      {
        mm.Subject = "Subject ";
        mm.Body = "<html><head></head><body> Content</body></html>"; 
        mm.IsBodyHtml=true;                                                              
       SmtpClient smtp = new SmtpClient();
       smtp.Host = "smtp.gmail.com";
       smtp.EnableSsl = false;
       NetworkCredential NetworkCred = new NetworkCredential("From", "password");
                       smtp.UseDefaultCredentials = false;
                       smtp.Credentials = NetworkCred;
                       smtp.Port = 587;
                       smtp.Timeout = 2000000;
                       smtp.Send(mm);
                       return "Success";  
       }
    }
