    void aTimer_Tick(object sender, EventArgs e)
    {
        aTimer.Stop();
        btnNo.PerformClick();
    }
    private void btnNo_Click(object sender, EventArgs e)
    {
        aTimer.Stop();
        genericServerClient.HandleCall(false);
    }
    private void btnOk_Click(object sender, EventArgs e)
    {
        aTimer.Stop();
        genericServerClient.HandleCall(false);
    }
