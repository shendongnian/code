    dt.Columns.Add(dc1);
    dt.Columns.Add(dc2);
    dt.Columns.Add(dc3);
    dt.Columns.Add("smtp", typeof(DataTable));
    dt.Columns.Add("imap", typeof(DataTable));
    
    dtsmtp.Rows.Add("smtp.myserver.de", "25", "STARTTLS", "Password");
    dtimap.Rows.Add("imap.myserver.de", "993", "STARTTLS", "Password");
    
    dt.Rows.Add("myusername", "mypassword", "me@myserver.de", dtsmtp, dtimap);
