    string htmlBody = "<html><body><h1>Picture</h1><br><img src=\"cid:filename\"></body></html>";
     AlternateView avHtml = AlternateView.CreateAlternateViewFromString
        (htmlBody, null, MediaTypeNames.Text.Html);
    
    var fileName = Guid.NewGuid.ToString();
    var path = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)),
        fileName);
    File.WriteAllBytes(path, Properties.Resources.Pic);
     LinkedResource inline = new LinkedResource(path, MediaTypeNames.Image.Jpeg); //Jpeg or something
     inline.ContentId = Guid.NewGuid().ToString();
     avHtml.LinkedResources.Add(inline);
    
     MailMessage mail = new MailMessage();
     mail.AlternateViews.Add(avHtml);
    
     Attachment att = new Attachment(filePath);
     att.ContentDisposition.Inline = true;
    
     mail.From = from_email;
     mail.To.Add(data.email);
     mail.Subject = "Here is your subject;
     mail.Body = String.Format(
                "Here is the previous HTML Body" +
                @"<img src=""cid:{0}"" />", inline.ContentId);
    
     mail.IsBodyHtml = true;
     mail.Attachments.Add(att);
