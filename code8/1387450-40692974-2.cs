    // Sends email using SMTP, Uses default network credentials
    public static void SendEmail(string To, string From, string BCC, string    Subject, string Body, bool IsBodyHtml, string attachedPath = "") {
        char[] validSeperators = new char[] { ',', ':', ';' };
        string fromEmail = string.Empty;
        foreach (char seperator in validSeperators) {
            if (!string.IsNullOrEmpty(From) && From.Contains(seperator.ToString())) {
                fromEmail = From.Split(seperator)[0];
                break;
            }
        }
        //create mail message
        MailMessage message = !string.IsNullOrEmpty(fromEmail) ? new MailMessage(fromEmail, To) : new MailMessage(From, To);
        if (BCC.Length > 0) {
            message.Bcc.Add(BCC);
        }
        message.IsBodyHtml = IsBodyHtml;
        message.Subject = Subject;
        message.Body = Body;
        // Email Attachment
        if (!string.IsNullOrEmpty(attachedPath)) {
            Attachment attach = new Attachment(attachedPath);
            // Attach the created email attachment 
            message.Attachments.Add(attach);
        }
        //create mail client and send email
        SmtpClient emailClient = new SmtpClient();
        emailClient.Host = SMTPServer;
        emailClient.Port = SMTPPort;
        emailClient.Credentials = new NetworkCredential(SMTPUserName, SMTPPassword);
        emailClient.EnableSsl = EnableSSLForSMTP;
        emailClient.Send(message);
        //Here you can dispose it after sending the mail.
        message.Dispose();
        //Remove specific file after sending mail to customer
        if (!string.IsNullOrEmpty(attachedPath))
            DeleteAttachedFile(attachedPath);
    }
    //Method to remove attached file from specific path.
    private static void DeleteAttachedFile(string attachedPath) {
        File.SetAttributes(attachedPath, FileAttributes.Normal);
        File.Delete(attachedPath);
    }
