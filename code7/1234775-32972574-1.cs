    public void CreateAttachment(string encryptedString, string fileName)
    {
        MemoryStream ms = new MemoryStream(
            ASCIIEncoding.ASCII.GetBytes(encryptedString)
        );
        Attachment attachment = new Attachment(ms, new ContentType("text/bzk"));
        attachment.Name = fileName + ".bzk";
        mail.Attachments.Add(attachment);
    }
