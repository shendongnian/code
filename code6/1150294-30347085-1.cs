    void outlookApp_ItemSend(object Item, ref bool Cancel)
    {
        if (Item is Outlook.MailItem)
        {
            string subject = ((Outlook.MailItem)Item).Subject;
            if (subject == "Test")
            {
                //Item sent
            }
        }
    }
