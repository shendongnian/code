    private void demoAlertToolStripMenuItem_Click(object sender, EventArgs e)
    {
        timer1.Enabled = !timer1.Enabled;
        demoAlertToolStripMenuItem.ForeColor = timer1.Enabled ? Color.Black : Color.Red;
    }
