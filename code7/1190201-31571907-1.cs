    var path = HttpContext.Current.Server.MapPath("OutlookCalendar.ics");
    using (Attachment mailAttachment = new Attachment(path))
    {
        mail.Attachments.Add(mailAttachment);
        mail.IsBodyHtml = true;
        //Set email message and subjet
        mail.Subject = header;
        mail.Body = message;
        smtpClient.Send(mail);
    }
