    using (var read_stream = File.OpenRead(path))
    {
        var attachment = new MimePart("image", "gif")
        {
            ContentObject = new ContentObject(File.OpenRead(path), ContentEncoding.Default),
            ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
            ContentTransferEncoding = ContentEncoding.Base64,
            FileName = Path.GetFileName(path)
        };
        var body = new TextPart("plain")
        {
            Text = "Meine ICal Mail"
        };
        //Configure Email
        var multipart = new Multipart("mixed");
        multipart.Add(body);
        multipart.Add(attachment);
        message.Body = multipart;
        //Send Email
        using (var client = new SmtpClient())
        {
            client.Connect(HostName, Port, false);
            client.Authenticate(UserName, Password);
            client.Send(message);
            client.Disconnect(true);
        }
    }
    //Delete file after sending
    File.Delete(path);
