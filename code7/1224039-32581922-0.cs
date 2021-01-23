    private bool CheckIsDuplicate(MailItem item)
    {
        //load the target pst
        Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
       Microsoft.Office.Interop.Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
       outlookNs.AddStore(@"D:\pst\Test.pst");
       Microsoft.Office.Interop.Outlook.MAPIFolder emailFolder = outlookNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
    
       //check for your mail item in the repository
       var duplicateItem = (
           from email in
           emailFolder.Items.OfType<MailItem>()
           where //here you could try a number of things a hash value of the properties or try using the item.I
           email.SenderName == item.SenderName &&
           email.To == item.To &&
           email.Subject == item.Subject &&
           email.Body == item.Body
           select email
               ).FirstOrDefault();
    
           return duplicateItem != null;
    }
