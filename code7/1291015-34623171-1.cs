    protected void btnRace_Click(object sender, EventArgs e)
    {
        // Should not be required but....
        if(UserClick != null)
        {
            UserClick.BtnClicks++;
            UserClick.Add(0);
        }
    }
