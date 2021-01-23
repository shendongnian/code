    for (int t = objFolder.Items.Count; t >= 1; t--)
    {
        try
        {
            if (!(objFolder.Items[t] is MailItem)) continue;
            MailItem m = objFolder.Items[t];
            if (m.Unread) { do_stuff(); }
        }
        catch { }
    }
