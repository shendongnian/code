     EmailMessage emailMessage = new EmailMessage()
     {
           Subject = "App Feedback " + Package.Current.DisplayName + " " + ApplicationServices.CurrentDevice,
           Body = "First Line\r\nSecondLine" 
     };
     emailMessage.To.Add(new EmailRecipient() { Address = "admin@DotNetRussell.com" });
     await EmailManager.ShowComposeNewEmailAsync(emailMessage);
