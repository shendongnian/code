    var newMsg = (MimeKit.MimeMessage)progressChangedEventArgs.UserState;
    if (newMsg != null)
    {
        ListViewCostumControl.lvnf.Items.Add(new ListViewItem(new string[]
        {
          newmsg.From.ToString(),         
          newmsg.Subject,                 
          newmsg.Date.ToString() 
        }));
    }
