    public static bool SendEmail(string subject, MailAddress from, List<string> to,List<string> cc, string body, Attachment attachment)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.Subject = subject;
            mail.From = from;
            foreach (var item in to)
                mail.To.Add(item);
            foreach (var item in cc)
                mail.CC.Add(item);
            mail.IsBodyHtml = true;
            mail.Body = body;
            if (attachment != null)
                mail.Attachments.Add(attachment);
            SmtpClient mailClient = new SmtpClient();
            mailClient.Port = 587;//maybe 25
            mailClient.Host = "smtp.gmail.com";
            mailClient.EnableSsl = true;
            mailClient.Credentials = new NetworkCredential("EmailAddress", "EmailPassword");
			//mailClient.Credentials = new NetworkCredential("a@gmail.com", "1234");
            try
            {
                mailClient.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        catch { return false; }
    }
