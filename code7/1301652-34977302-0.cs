    try
    {
      Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
      Outlook._NameSpace ns = app.GetNamespace("MAPI");
      ns.Logon(null, null, false, false);
      Outlook.MAPIFolder inboxFolder = ns.GetDefaultFolder(OlDefaultFolders.olFolderInbox);
      // loop through the folder to find the email - match on subject
      for (int i=1; i <= inboxFolder.Items.Count; i++)
      {
        Outlook._MailItem item = (Microsoft.Office.Interop.Outlook._MailItem)inboxFolder.Items[i];
        if (item.Subject == eMailItem.Subject)
        {
          // found original message, reply to it
          Outlook._MailItem reply = item.Reply();
          reply.HTMLBody = eMailItem.HTMLBody;
          reply.Send();
          break;
        }
      }
    }
    catch
    {
    }
