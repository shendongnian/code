     public static bool sendMailFromToCCSubMsgAttachment(string fromName, string fromAdd, string toline, string subj, string htmlmsg, string cc, List<string> strAttachment)
            {
    
                SmtpClient smtpClient = new SmtpClient(ConfigurationSettings.AppSettings["MAIL_SERVER"], Int32.Parse(ConfigurationSettings.AppSettings["SERVER_PORT"]));
                MailMessage mail = new MailMessage();
                string strAttachmentboyd = string.Join(Environment.NewLine, strAttachment);
                // your other code
            }
