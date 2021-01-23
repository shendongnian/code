    var mail = new MailMessage();
    mail.IsBodyHtml = true;
    
    var inline = new LinkedResource(@"C:\path\to\your\image.png");
    inline.ContentId = Guid.NewGuid().ToString();
    var htmlBody = @"<img src='cid:" + inline.ContentId + @"'/>"; // Include whatever other content in the html body here.
    var alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
    alternateView.LinkedResources.Add(inline);
    
    mail.AlternateViews.Add(alternateView);
