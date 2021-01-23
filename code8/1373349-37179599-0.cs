    public static string SendMail(string stHtmlBody, string stSubject, string stToEmailAddresses)
    {
        string stReturnText = string.Empty;
        try
        {
            if (!string.IsNullOrEmpty(stToEmailAddresses))
            {
                //Set SmtpClient to send Email
                string stFromUserName = "fromusername";
                string stFromPassword ="frompassword";
                int inPort = Convert.ToInt32(587);
                string stHost = "smtp.gmail.com";
                bool btIsSSL =true;
                MailAddress to = new MailAddress(stToEmailAddresses);
                MailAddress from = new MailAddress("\"" + "Title" + "\" " + stFromUserName);
                MailMessage objEmail = new MailMessage(from, to);
                objEmail.Subject = stSubject;
                objEmail.Body = stHtmlBody.ToString();
                objEmail.IsBodyHtml = true;
                objEmail.Priority = MailPriority.High;
               
                SmtpClient client = new SmtpClient();
                System.Net.NetworkCredential auth = new System.Net.NetworkCredential(stFromUserName, stFromPassword);
                client.Host = stHost;
                client.Port = inPort;
                client.UseDefaultCredentials = false;
                client.Credentials = auth;
                client.EnableSsl = btIsSSL;
                client.Send(objEmail);
                return stReturnText;
            }
        }
        catch (Exception ex)
        {
        }
        return stReturnText;
    }
