    private async void Button1_Click(object sender, EventArgs e)
    {
        var f = new Form(); //Your progress form
        f.Show(this);
        this.Enabled = false;
        try
        {
            //For example a time-consuming task
            await Task.Delay(5000);
        }
        catch (Exception ex)
        {
            //Handle probable exceltions
        }
        f.Close();
        this.Enabled = true;
        this.BringToFront();
    }
