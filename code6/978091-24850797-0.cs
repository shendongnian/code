    private void oKToolStripMenuItem2_Click(object sender, EventArgs e)
    {
        ...
        var username = usernamesToolStripMenuItem1.DropDownItems.Add(toolStripTextBox3.Text);
        username.Click += username_Click;
        ...
    }
    void username_Click(object sender, EventArgs e)
    {
        SomeTextBox.Text = "test";
    }
