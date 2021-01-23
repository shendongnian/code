    protected void telList_OnClick(object sender, BulletedListEventArgs e)
    {
        var contacts = new List<string> { "aa", "ab", "cccc" };
        char clickeckChar = "ABCÇDEFGHIİJKLMNOÖPRSŞTUÜVYZ"[e.Index];
        rptTable.DataSource = 
            contacts
            .Where(contact => contact.ToUpper().StartsWith(clickeckChar.ToString().ToUpper()))
            .ToList();
        rptTable.DataBind();
    }
