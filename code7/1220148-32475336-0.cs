            try
            {
                SmtpClient Smtp_Server = new SmtpClient();
                MailMessage e_mail = new MailMessage();
              //code here for mail message and client configuration
                Smtp_Server.Send(e_mail);
                MessageBox.Show("mail send successfully");
            }
            catch (Exception)
            {
                MessageBox.Show("failed to send mail");
            }
