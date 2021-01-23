    SmtpClient client = new SmtpClient();
    foreach (DataRow row in accounts.Tables[0].Rows)
    {
        string cust = row["Account"].ToString();
        string site = row["Ledger"].ToString();
        string mail = row["Email"].ToString();
        MailMessage msg = new MailMessage
        {
            From = new MailAddress(site),
            Subject = "Hello!",
            Body = "..."
        };
        msg.To.Add(new MailAddress(mail));
        client.Send(msg);
    }
