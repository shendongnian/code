    public void CreateAttachment(string encryptedString, string fileName)
    {
        MemoryStream ms = new MemoryStream(
            ASCIIEncoding.ASCII.GetBytes(encryptedString)
        );
        Attachment = new Attachment(ms, new ContentType("text/bzk"));
        Attachment.Name = fileName + ".bzk";
        mail.Attachments.Add(Attachment);
    }
