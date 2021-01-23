    private void denMailButton_Click(object sender, EventArgs e)
    {
        string subject = "Subject";
        string body = @"Image 1: <img src=""$CONTENTID1$""/> <br/> Image 2: <img src=""$CONTENTID2$""/> <br/> Some Other Content";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("from@example.com");
        mail.To.Add(new MailAddress("to@example.com"));
        mail.Subject = subject;
        mail.Body = body;
        mail.Priority = MailPriority.Normal;
        string contentID1 = Guid.NewGuid().ToString().Replace("-", "");
        string contentID2 = Guid.NewGuid().ToString().Replace("-", "");
        body = body.Replace("$CONTENTID1$", "cid:" + contentID1);
        body = body.Replace("$CONTENTID2$", "cid:" + contentID2);
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(body, null, "text/html");
        //path of image or stream
        LinkedResource imagelink1 = new LinkedResource(@"D:\1.png", "image/png");
        imagelink1.ContentId = contentID1;
        imagelink1.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
        htmlView.LinkedResources.Add(imagelink1);
        mail.AlternateViews.Add(htmlView);
        LinkedResource imagelink2 = new LinkedResource(@"D:\2.png", "image/png");
        imagelink2.ContentId = contentID2;
        imagelink2.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
        htmlView.LinkedResources.Add(imagelink2);
        mail.AlternateViews.Add(htmlView);
        SmtpClient client = new SmtpClient();
        client.Host = "mail.example.com";
        client.Credentials = new NetworkCredential("from@example.com", "password");
        client.Send(mail);
    }
   
