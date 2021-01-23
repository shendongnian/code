        public static void Send(string subject, string message, params string[] recipients)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            System.Net.NetworkCredential nc = new System.Net.NetworkCredential([YourAccountName], [YourAccountPassword]);//username doesn't include @gmail.com
            client.UseDefaultCredentials = false;
            client.Credentials = nc;
            client.EnableSsl = true;
            client.Port = 587;
            try
            {
                string recipientString = string.Join(",", recipients);
                client.SendAsync([YourAccountName] + "@gmail.com", recipientString, subject, message, null);
            }
            catch (Exception ex)
            {
                Logger.Report(ex);
            }
        }
