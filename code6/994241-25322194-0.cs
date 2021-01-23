    public async void MyButtonHandler(object sender, EventArgs e)
    {
       EmailRecipient sendTo = new EmailRecipient()
       {
           Address = "abc@outlook.com"
       };
    
       //generate mail object
       EmailMessage mail = new EmailMessage();
       mail.Subject = "Feedback";
    
       //add recipients to the mail object
       mail.To.Add(sendTo);
       //mail.Bcc.Add(sendTo);
       //mail.CC.Add(sendTo);
    
       //open the share contract with Mail only:
       await EmailManager.ShowComposeNewEmailAsync(mail);
    }
