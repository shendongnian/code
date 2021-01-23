    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        Project.Properties.Settings.Default.rememberMe = checkBox1.Checked;
        Project.Properties.Settings.Default.Save();
    }
