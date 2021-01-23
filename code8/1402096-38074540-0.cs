    if (mail.Attachments.Count > 0)
    {
        for (int i = 1; i <= mail.Attachments.Count; i++)
        {
            mail.Attachments[i].SaveAsFile(@"C:\Test\" + mail.Attachments[i].FileName);
        }
    }
