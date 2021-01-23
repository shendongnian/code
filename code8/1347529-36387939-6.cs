    private void moduleToolStripMenuItem_Click(object sender, EventArgs e)
    {
        NewModule newmodule = new NewModule();
        newmodule.FormClosing += F_FormClosing
        newmodule.Show();
    }
    private void F_FormClosing(object sender, FormClosingEventArgs e)
    {
        LoadComboBox();
    }
