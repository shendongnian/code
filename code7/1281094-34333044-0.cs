    using (var attachment1 = new System.Net.Mail.Attachment(path1))
    using (var attachment2 = new System.Net.Mail.Attachment(path2))
    {
        SendEmail("message", "subject", attachment1, attachment2);
    }
