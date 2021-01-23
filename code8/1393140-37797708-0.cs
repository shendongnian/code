    void Application_ItemSend(object Item, ref bool Cancel)
    {
       Outlook.MailItem mailItem = Item as Outlook.MailItem;
       if (mailItem != null)
       {
           MessageBox.Show("I am a MailItem");
       }
       else
       {
          Outlook.MeetingItem meetingItem = Item as Outlook.MeetingItem;
          if (meetingItem != null)
          {
              MessageBox.Show("I am a MeetingItem");
           }
       } 
    }
