    private void timer2_Tick(object sender, EventArgs e)
    {
        timer1.Stop();
        timer2.Stop();
        SampTool sampTool = new SampTool();
        sampTool.Show();
        Hide();  // call the Forms Hide function.
    }
