    private void HandleRadioSelection()
    {
        if (radioButton1.Checked)
        {
            this.SendMailMessage("Daily load done.", "The daily load process has completed.");
        }
        else
        {
            this.SendMailMessage("Some other subject", "Some other body");
        }
    }
    
    private void SendMailMessage(string subject, string body)
    {
        using (MailMessage mailMessage = new MailMessage("you@yourcompany.com", "user@hotmail.com", subject, body))
        {
            Mailer.Send(mailMessage);
        }
    }
