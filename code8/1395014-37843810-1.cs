    private void btnSaveCommands_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default.command1 = commandTextBox1.Text;
        Properties.Settings.Default.command2 = commandTextBox2.Text;
        etc..... (35 times)
        Properties.Settings.Default.Save();
    }
