    private void demoAlertToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(timer1.Enabled)
        {
            demoAlertToolStripMenuItem.ForeColor = Color.Red;
            timer1.Stop();
        }
        else
        {
            demoAlertToolStripMenuItem.ForeColor = Color.Black;
            timer1.Start();
        }
    }
