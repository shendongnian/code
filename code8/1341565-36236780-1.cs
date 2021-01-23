    private void newsListening_CheckedChanged(object sender, EventArgs e)
    {
        newsTimer.Enabled = newsListening.Checked;
        if (newsTimer.Enabled) newsTimer_Tick(null, null); do one download immediately!
    }
