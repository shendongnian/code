    public void Mail(string receiver, string subject, string body)
    {
      Outlook.Application outlook = System.Diagnostics.Process.GetProcessesByName("OUTLOOK").Length > 0
        ? Marshal.GetActiveObject("Outlook.Application") as Outlook.Application
        : new Outlook.Application();
      Outlook.MailItem mailItem = outlook.CreateItem(Outlook.OlItemType.olMailItem) as Outlook.MailItem;
      if (mailItem == null) throw new Exception("Outlook failed!");
      mailItem.To = receiver ?? string.Empty;
      mailItem.Subject = subject;
      mailItem.Body = body;
      mailItem.Display();
    }
