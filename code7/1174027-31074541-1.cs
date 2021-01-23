    SmtpClient client = new SmtpClient();
    foreach (DataRow row in accounts.Tables[0].Rows)
    {
        string cust = row["Account"].ToString();
        string site = row["Ledger"].ToString();
        string mail = row["Email"].ToString();
        //Get your email address, say, from the app.config file
        string fromAddress = GetFromAddressBySite(site);
        MailMessage msg = new MailMessage
        {
            From = new MailAddress(fromAddress),
            Subject = "Hello!",
            Body = "..."
        };
        msg.To.Add(new MailAddress(mail));
        client.Send(msg);
    }
