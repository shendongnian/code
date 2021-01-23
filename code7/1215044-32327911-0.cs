    connection.Open();
    varcommand1 = new OleDbCommand();
    command1.Connection = connection;
    varcq = "Select Email From student where S_ID in(select S_ID FROM studentbook where DateDiff('d',[Issue_Date], NOW())=31) ";
    command1.CommandText = cq;
    varda1 = new OleDbDataAdapter(command1);
    vardt1 = new DataTable();
    da1.Fill(dt1);
    using (var mm = new MailMessage())
    {
        foreach (DataRow row in dt1.Rows)
        {
            varemail = row["Email"].ToString();
            if(string.IsNullOrWhitespace(email))
                continue;
            mm.Bcc.Add(email);   
        }
        mm.From.Add("SenderEmailAddress");   
        mm.Subject = "Attention please,renew your book";
        mm.Body = string.Format("1 month over,you should renew or return the book");
    
        mm.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.EnableSsl = true;
        var credentials = new System.Net.NetworkCredential();
        credentials.UserName = "xxxxxxxxxxxxx";
        credentials.Password = "xxxxxxxxxx";
        smtp.UseDefaultCredentials = true;
        smtp.Credentials = credentials;
        smtp.Port = 587;
        smtp.Send(mm);
    }
