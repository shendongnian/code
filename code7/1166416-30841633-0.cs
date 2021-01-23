     using Outlook = Microsoft.Office.Interop.Outlook;
     //Create the email with the settings
     Outlook.Application outlookApp = new Outlook.Application();
     Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
     mailItem.Subject = mailSubject;
     mailItem.Attachments.Add(totalPath);
     mailItem.Body = mailBody;
     mailItem.Importance = Outlook.OlImportance.olImportanceNormal;
     try
     {
         //Try to open outlook, set message if its not possible to open outlook
         mailItem.Display(true);
     }
     catch (Exception ex)
     {
         MessageBox.Show(ex.Message);
         return false;
     }
