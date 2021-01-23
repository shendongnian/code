    //(Thanks to Mason for comment and Thanks to  Bartosz Kosarzyck for sample code)
    string subject = "Subject";
    string body = @"<img src=""$CONTENTID$""/> <br/> Some Content";
    MailMessage mail = new MailMessage();
    mail.From = new MailAddress("from@example.com");
    mail.To.Add(new MailAddress("to@example.com"));
    mail.Subject = subject;
    mail.Body = body;
    mail.Priority = MailPriority.Normal;
    string contentID = Guid.NewGuid().ToString().Replace("-", "");
    body = body.Replace("$CONTENTID$", "cid:" + contentID);
    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
    //path of image or stream
    LinkedResource imagelink = new LinkedResource(@"C:\Users\R.Aghaei\Desktop\outlook.png", "image/png");
    imagelink.ContentId = contentID;
    imagelink.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
    htmlView.LinkedResources.Add(imagelink);
    mail.AlternateViews.Add(htmlView);
    SmtpClient client = new SmtpClient();
    client.Host = "mail.example.com";
    client.Credentials = new NetworkCredential("from@example.com", "password");
    client.Send(mail);
