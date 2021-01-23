    static void WriteOutlookContactPhotoToFile(ContactItem contact, string directory, string fileName)
    {
        if (contact != null && contact.HasPicture)
        {
            var attachment = contact.Attachments["ContactPicture.jpg"] as Attachment;
            if (attachment != null)
            {
                string writePath = Path.Combine(directory, fileName);
                attachment.SaveAsFile(writePath);
            }
        }
    }
