    private static bool SendEmail(string emailBody, string emailSubject)
     {
       try
       {
        Email email = new Email();
        email.To.Add("POvermyer@TandT.com");
        email.Subject = emailSubject;
        email.Body = emailBody;
        email.Send();
        return true;
       }
       catch(Exception ex)
       {
        return false; 
       }
    }
 
