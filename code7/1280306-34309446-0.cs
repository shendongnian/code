    var attachment = mailObject as IAttachment;
    if (attachment != null)
    {
        foreach (var att in attachment.GetAttachments())
        {
            mail.Attachmenets.Add(att);
        }
    }
