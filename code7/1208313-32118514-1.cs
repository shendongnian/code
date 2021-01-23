    void firstToolStripMenuItem_MouseUp(object sender, MouseEventArgs e)
    {
        var toolStripMenuItem = (ToolStripMenuItem)sender;
        var nullIfOtherType = sender as ToolStripMenuItem;
        var right = e.Button == System.Windows.Forms.MouseButtons.Right;
    }
