     void SendMail_Click(object sender, EventArgs e)
            {
                var email = new Dto.IEmail();
                if (EmailBody.Text == string.Empty && EmailSubject.Text == string.Empty)
                {
                    XtraMessageBox.Show("please fill email body and subject");
                    return;
                }
                email.Body = EmailBody.Text;
                email.Subject = EmailSubject.Text;
                email.EmailAddress = "email@gmail.com";
                email.ToAddress = "email@gmail.com";
    
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
    
                    message.From = new MailAddress(email.EmailAddress);
                    message.To.Add(new MailAddress(email.ToAddress));
                    message.Subject = email.Subject;
                    message.Body = email.Body + "\n From user " + GlobalClass.UserLogin.USERNAME + "\n with body: " + _reportedfile;
    
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(email.EmailAddress, "gmailpassword");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("err: " + ex.Message);
                }
            }
