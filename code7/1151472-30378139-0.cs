    public void AddAttachment(MailItem mail)
    {
        OpenFileDialog attachment = new OpenFileDialog();
        attachment.Title = "Select files to attach";
        attachment.ShowDialog();
            if (attachment.ShowDialog() == DialogResult.OK)
        {
            mail.Attachments.Add(attachment.FileName, Outlook.OlAttachmentType.olByValue, 1, attachment.FileName);
        }
     }
     private void CreateMailItem()
     {
        Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
        Microsoft.Office.Interop.Outlook.MailItem mail = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
        mail.Subject = "";
        mail.To = "";
        mail.CC = "";
        mail.Body = "";
        mail.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceNormal;
        AddAttachment(mail);
        mail.Display(false);
     } 
