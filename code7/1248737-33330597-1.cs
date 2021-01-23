    List<Emails> mailInfoList = new List<Emails>();
    if (ds.Tables[0].Rows.Count > 0)
    {
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            Emails email = new Emails();
            email.Subject = row["Subject"].ToString();
            email.EmailFrom = row["EmailFrom"].ToString();
            email.EmailTo = row["EmailTo"].ToString();
            email.EmailCc = row["EmailCc"].ToString();
            email.EmailContent = row["EmailContent"].ToString();
            email.CreatedOn = Convert.ToDateTime(row["CreatedOn"].ToString());
            mailInfoList.Add(email);
        }
        var newList = mailInfoList.OrderBy(c => c.EmailFrom).ThenBy(n => n.CreatedOn);
    }
