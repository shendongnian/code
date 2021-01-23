    public void tmrEmail_Tick(object sender, EventArgs e)
    {
        // The following line will produce a compile error because
        // CheckForEmails doesn't return a value
        // lblEmail.Text = ("New Emails " + RSSFeed.CheckForEmails(this);
        // Try this instead:
        RSSFeed.CheckForEmails(this);
    }
