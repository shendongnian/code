     public void SendAsyncMail()
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("Enter from mail address");
            mail.To.Add(new MailAddress("Enter to address #1"));
            mail.To.Add(new MailAddress("Enter to address #2"));
            mail.Subject = "Enter mail subject";
            mail.Body = "Enter mail body";
            SmtpClient smtpClient = new SmtpClient();
            Object state = mail;
            //event handler for asynchronous call
            smtpClient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
            try
            {
                smtpClient.SendAsync(mail, state);
            }
            catch (Exception ex)
            {
            }
        }
        void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MailMessage mail = e.UserState as MailMessage;
            if (!e.Cancelled && e.Error != null)
            {
                //message.Text = "Mail sent successfully";
            }
        }
