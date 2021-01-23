    using (System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(HOST, PORT))
    {
        client.Credentials = new System.Net.NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);
        client.EnableSsl = true;
        for(i=0;i<mail.Count;i++)
                {
                    String TO = mail[i];
                    System.Net.Mail.MailMessage message1 = new System.Net.Mail.MailMessage(FROM, TO, SUBJECT, BODY);
                    message1.IsBodyHtml = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(message1);
                }
        client.Dispose();
    }
    Label1.Text = mail.Count.ToString() + " mails sent !!";
}
