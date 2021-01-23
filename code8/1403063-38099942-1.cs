    public static void sendMailWithAttachment(string strAttachment)
    {
    //insert the licence into a memorystream.
    //Note not using the 'using' statement with the MemoryStream and StreamWriter.
    //If you do you will get a 'cannot access a closed stream' error when attaching the stream into the email
    MemoryStream stream = new MemoryStream();
    StreamWriter writer = new StreamWriter(stream);
    writer.Write(strAttachment);
    writer.Flush();
    stream.Position = 0;
    //start the mail sending
    using (SmtpClient client = new SmtpClient())
    using (MailMessage oMail = new MailMessage())
    {
        //mail config settings
        client.Port = 25;
        client.Host = "localhost";
        client.Timeout = 30000;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("userName", "passWord");
        //mail content stuff
        oMail.From = new MailAddress("fake@false.nl", "yourName");
        oMail.To.Add(new MailAddress("fake@false.nl"));
        oMail.Subject = "Your Licence";
        oMail.IsBodyHtml = true;
        oMail.Body = "<html><head></head><body> Hello </body></html>";
        //insert the text file as attatchment from the stream
        if (!string.IsNullOrEmpty(strAttachment))
        {
            oMail.Attachments.Add(new Attachment(stream, "Licence.txt", "text/plain"));
        }
        //send the mail
        client.Send(oMail);
    }
    //dispose the stream and writer containing the license
    writer.Dispose();
    stream.Dispose();
    }
