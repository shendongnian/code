    using (var smtp = new SmtpClient())
    {   
        var message = new MailMessage();
    
        message.To.Add(email);
        message.Subject = "Subject";
    
        // HTML
        message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html));
    
        // VCARD
        System.Net.Mime.ContentType loCalendarType = new System.Net.Mime.ContentType("text/calendar; method=REQUEST");
        AlternateView icalView = AlternateView.CreateAlternateViewFromString(ical, loCalendarType);
        icalView.TransferEncoding = TransferEncoding.Base64;
        message.AlternateViews.Add(icalView);
    
        smtp.Send(message);
    }
