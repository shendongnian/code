     using System;
    public  class EnvVars
        {
    
            public static EnvVars GetSettings()
            {  
                EnvVars envVars = new EnvVars();
            try{
                //TODO - log begin work
            String[] files = Directory.GetFiles(@"H:\\EDI", "*.brl", SearchOption.AllDirectories);
            if (files.Length > 0)
            {
                var mail_server1 = ConfigurationManager.AppSettings.Get("mail_server");
                var mail_from_address1 = ConfigurationManager.AppSettings.Get("mail_from_address");
                var mail_address1 = ConfigurationManager.AppSettings.Get("mail_address");
                MailMessage mm = new MailMessage(mail_from_address1, mail_address1);
                mm.Body = ConfigurationManager.AppSettings.Get("body");
                mm.Subject = ConfigurationManager.AppSettings.Get("subject");
                mm.IsBodyHtml = true;
                int leng = files.Length;
                for (int i = 0; i < files.Length; i++)
               {
                  String sep = "   |  ";
                    String Body1 = String.Join(sep, files, 0, leng);
                   mm.Body = Body1;
                }
                SmtpClient client = new SmtpClient(mail_server1);
              
                    client.Send(mm);
                
            }
            }
                catch (Exception e)
            {
                    //TODO - log exception
                }
            
            finally
            {
           return envVars;
            }
        }
    }
}
