    private void oKToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(toolStripTextBox3.Text))
        {
            MessageBox.Show("Please enter a username in the textbox.", "Error");
            return;
        }
        var username = usernamesToolStripMenuItem1.DropDownItems.Add(
                             new ToolStripLabel(toolStripTextBox3.Text, (Image) null,
                             false, toolstrip_click));
        username.Name = toolStripTextBox3.Text;
        Properties.Settings.Default.Usernames.Add(toolStripTextBox3.Text);
        toolStripTextBox3.Clear();
    }
    void toolstrip_click(object sender, EventArgs e)
    {
        MessageBox.Show(((ToolStripLabel)sender).Text);  // Write your code here
    }
