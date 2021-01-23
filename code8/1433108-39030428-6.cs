    using (var mailMessage = new MailMessage())
    {
        using (var smtpClient = new SmtpClient())
        {
            foreach (workbook excel in workbooks)
            {
                MemoryStream memoryStream = new MemoryStream();
                excel.hssfWorkBook.Write(memoryStream);
                memoryStream.Position = 0;
                mailMessage.Attachments.Add(new Attachment(memoryStream, excel.fileName, "application/vnd.ms-excel"));
            }
            smtpClient.Send(mailMessage);
        }
    }
