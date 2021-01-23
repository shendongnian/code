    var builder = new BodyBuilder ();
    var pathImage = Path.Combine (Misc.GetPathOfExecutingAssembly (), "Image.png");
    var image = builder.LinkedResources.Add (pathLogoFile);
    
    image.ContentId = MimeUtils.GenerateMessageId ();
    
    builder.HtmlBody = string.Format (@"<p>Hey!</p><img src=""cid:{0}"">", image.ContentId);
    
    message.Body = builder.ToMessageBody ();
