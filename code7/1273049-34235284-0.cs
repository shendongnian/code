            ActiveUp.Net.Mail.Message message = new ActiveUp.Net.Mail.Message();
            // We assign the sender email
            message.From.Email = this.fromEmailTextbox.Text;
            // We assign the recipient email
            message.To.Add(this.toEmailTextbox.Text);
            
            // We assign the subject
            message.Subject = this.subjectTextbox.Text;
            // We assign the body text
            message.BodyText.Text = this.bodyTextTextbox.Text;
            // We send the email using the specified SMTP server
            this.AddLogEntry("Sending message.");
            try
            {
                SmtpClient.Send(message, this.smtpServerAddressTextbox.Text);
                this.AddLogEntry("Message sent successfully.");
            }
            catch (SmtpException ex)
            {
                this.AddLogEntry(string.Format("Smtp Error: {0}", ex.Message));
            }
            catch (Exception ex)
            {
                this.AddLogEntry(string.Format("Failed: {0}", ex.Message));
            }
