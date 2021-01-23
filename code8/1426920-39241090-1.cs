    // create the alternative views
    var textBody = new TextPart("plain") { Text = message.TextBody };
    var htmlBody = new TextPart("html") { Text = message.HtmlBody };
    // add views to the multipart/alternative
    var alternative = new Multipart("alternative");
    alternative.Add(textBody);
    alternative.Add(htmlBody);
    if (!string.IsNullOrWhiteSpace(message.CalendarInvite))
    {
        // also add the calendar as an alternative view
        // encoded as base64, but 7bit will also work
        var calendarBody = new TextPart("calendar")
        {
            Text = message.CalendarInvite,
            ContentTransferEncoding = ContentEncoding.Base64
        };
        // most clients wont recognise the alternative view without the 
        // method=REQUEST header
        calendarBody.ContentType.Parameters.Add("method", "REQUEST");
        alternative.Add(calendarBody);
    }
    // create the multipart/mixed that will contain the multipart/alternative
    // and all attachments
    var multiPart = new Multipart("mixed") { alternative };
    if (!string.IsNullOrWhiteSpace(message.CalendarInvite))
    {
        // add the calendar as an attachment
        var calAttachment = new MimePart("application", "ics")
        {
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = "invite.ics",
            ContentObject = new ContentObject(GenerateStreamFromString(message.CalendarInvite))
        };
        multiPart.Add(calAttachment);
    }
    // TODO: Add any other attachements to 'multipart' here.
    
    // build final mime message
    var mimeMessage = new MimeMessage();
    mimeMessage.From.Add(GetMimeAddress(message.MessageInfo.SenderName, message.MessageInfo.SenderAddress));
    mimeMessage.To.Add(GetMimeAddress(message.MessageInfo.RecipientName, message.MessageInfo.RecipientAddress));
    mimeMessage.Subject = message.Subject;
    mimeMessage.Body = multiPart;
    // parse and return mime message
    return mimeMessage.ToString();
