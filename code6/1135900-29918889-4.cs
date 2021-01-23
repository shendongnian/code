    protected void Button1_Click(object sender, EventArgs e)
    {
        if (LastUpdate.AddSeconds(5.0) < DateTime.Now)
        {
            UpdatePanel1.Update();
            LastUpdate = DateTime.Now;
        }
    }
