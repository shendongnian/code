    private void timer1_Tick(object sender, EventArgs e)
    {
        TimeSpan ts = DateTime.Now - rfidConnectedTime;
        label6.Text = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
    }
