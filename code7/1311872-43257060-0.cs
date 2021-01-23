    EmailMessage email = new EmailMessage(service);
    email.Subject = "Test Email";
    email.Body = new MessageBody(BodyType.HTML, html);
    email.ToRecipients.Add("test@gmail.com");
    // Add the attachment to the local copy of the email message.
    string file = @"C:\projects\Party.jpg";
    MemoryStream stream = new MemoryStream();
    email.Attachments.AddFileAttachment("Party.jpg", file).Load(stream);
    byte[] imageBytes = stream.ToArray();
    // Convert byte[] to Base64 String
    string base64String = Convert.ToBase64String(imageBytes);
    stream.close();
    email.Attachments[0].IsInline = true;
    email.Attachments[0].ContentId = "Party.jpg";
    
    string html = @"<html>
    				<head>
    				</head>
    				<body>
    				<img width=100 height=100 id=""1"" src=""data: image/jpg;base64, " + base64String + """>
    				</body>
    				</html>";
         
