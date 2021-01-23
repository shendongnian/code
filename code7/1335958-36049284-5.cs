    public void tmrEmail_Tick(object sender, EventArgs e)
    {
        RSSFeed feed = new RSSFeed();
        feed.CheckForEmails(this);
    }
