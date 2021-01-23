    public void tmrEmail_Tick(object sender, EventArgs e)
    {
        RSSFeed feed = new RSSFeed();
        lblEmail.Text = ("New Emails " + feed.CheckForEmails(this);
    }
