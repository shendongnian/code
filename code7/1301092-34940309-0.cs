    foreach (var message in messages)
    {
        Emailed_Expenses email = null;
        
        foreach (var attachment in message.Attachments.CurrentPage)
        {
            FileAttachment file = attachment as FileAttachment;
            if (file != null)
            {
                if (email == null)
                {
                    email = new Emailed_Expenses
                    {
                        Email_Sender = message.Sender.ToString(),
                        Email_Subject = message.Subject,
                        Email_Attachment = new List<byte[]>
                    };
                }
                
                email.Email_Attachment.Add(file.ContentBytes);
            }
        }
        
        if (file != null)
        {
            star_Inbox.Add(email);
        }
    }
