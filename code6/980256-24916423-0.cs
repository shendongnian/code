        Outlook.Application app = new Outlook.Application();
        Outlook.NameSpace outlookNs = app.GetNamespace("MAPI");
        outlookNs.AddStore(@"D:\pst\Test.pst");
        Outlook.MAPIFolder emailFolder = outlookNs.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
        List<MailItem> lstMails = emailFolder.Items.OfType<MailItem>().Where(x=>x.SenderEmailAddress.Contains("hari")).Select(x=>x).ToList();
        foreach (Object obj in emailFolder.Items)
        {
           if(obj is MailItem)
            {
                MailItem item = (MailItem)obj;
               String user=String.Empty;
                foreach (Object obj1 in ((dynamic)item).Recipients)
                {
                    user += ((dynamic)obj1).Name + ";";
                }
                Console.WriteLine(user + " " + item.Subject + "\n" + item.Body);
            }
        }
