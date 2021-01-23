     Outlook.Application oApp = new Outlook.Application();
     //Create new email
     Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
     //Set recipients here
     Outlook.Recipient oRecip = (Outlook.Recipient)oMsg.Recipients.Add(myRecipientsVariable);
     //Check to make sure they're all valid recipients in my contact list
     oRecip.Resolve();
     //Stop recipients from being able to reply all
     oMsg.Actions["Reply to All"].Enabled = false;
     //Stop them from being able to reply
     oMsg.Actions["Reply"].Enabled = false;
     //Set the Subject line
     oMsg.Subject = "Test Subject Line";
     //Tidy Up
     oRecip = null;
     oMsg = null;
     oApp = null;
