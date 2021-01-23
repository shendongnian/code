    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.DontShow = this.checkBox1.Checked;
        Properties.Settings.Default.Save();
    }
