    public void SendEmailWithICal(string toEmailAddress, string subject, string textBody)
    {
        CalenderItems iCalender = new CalenderItems();
        iCalender.GenerateEvent("Neuer Kalendereintrag");
        var termin = iCalender.iCal;
        string path = "TempIcsFiles/file.ics";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        //Create file and write to it
        using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            using (var str = new StreamWriter(fs))
            {
                str.BaseStream.Seek(0, SeekOrigin.End);
                str.Write(termin.ToString());
                //Close Filestream and Streamwriter
                str.Flush();
            }
        }
        //Compose the message
        using (var read_stream = File.OpenRead(path))
        {
            using (var message = new MimeMessage())
            {
                message.From.Add(new MailboxAddress("Chronicus Dev", this.UserName));
                message.To.Add(new MailboxAddress(toEmailAddress.Trim(), toEmailAddress.ToString()));
                message.Subject = subject;
                //Add as Attachment
                var attachment = new MimePart("image", "gif")
                {
                    ContentObject = new ContentObject(read_stream, ContentEncoding.Default),
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
        }
        //Delete temporary file
        File.Delete(path);
    }
