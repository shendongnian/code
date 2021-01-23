    string message="255CharsLongMessage";
    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\\shareddata\temp\buoy.txt", false, System.Text.Encoding.ASCII))
            {
                file.WriteLine(message);
            }
    MailMessage emailMsg = new MailMessage();
    emailMsg.To.Add("destination@server.com");
    emailMsg.Subject = "My_Subject";
    emailMsg.From = new MailAddress("source@email.coom");
    emailMsg.BodyEncoding = System.Text.Encoding.ASCII;
    emailMsg.IsBodyHtml = false;
    SmtpClient smtp = new SmtpClient("SMTP_SERVER");
    Attachment data = new Attachment(@"\\shareddata\temp\buoy.txt", new ContentType("text/plain; charset=us-ascii"));
    emailMsg.Attachments.Add(data);
    data.ContentDisposition.Inline = true;
    data.TransferEncoding = TransferEncoding.SevenBit;
    smtp.Send(emailMsg);
