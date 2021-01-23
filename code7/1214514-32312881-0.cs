    private void toolStripMenuItem_MouseEnter(object sender, EventArgs e)
    {
        var item=(ToolStripMenuItem)sender;
        item.ForeColor = Color.Blue;
        item.Font = new Font(item.Font, FontStyle.Italic | FontStyle.Bold );
    }
    private void toolStripMenuItem_MouseLeave(object sender, EventArgs e)
    {
        var item = (ToolStripMenuItem)sender;
        item.ForeColor = Color.Green;
        item.Font = new Font(item.Font, FontStyle.Regular);
    }
