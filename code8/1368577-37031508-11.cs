    private void menuItem_MouseEnter(object sender, EventArgs e)
    {
        var item = (ToolStripMenuItem)sender;
        if (item.Text == "Yes")
            ToolStripManager.Renderer = g;
        else if (item.Text == "No")
            ToolStripManager.Renderer = r;
        else if (item.Text == "MayBe")
            ToolStripManager.Renderer = b;
        else
            ToolStripManager.Renderer = null; // or use your default renderer
    }
    private void menuItem_MouseLeave(object sender, EventArgs e)
    {
        ToolStripManager.Renderer = null; // or use your default renderer
    }
