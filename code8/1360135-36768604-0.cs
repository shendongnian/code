    ToolStripDropDown td;
    private void Form1_Load(object sender, EventArgs e)
    {
        td = new ToolStripDropDown { /*...*/};
        var host = new ToolStripControlHost(this.panel1){ /*...*/};
        td.Items.Add(host);
        td.Closing += td_Closing;
    }
    void td_Closing(object sender, ToolStripDropDownClosingEventArgs e)
    {
        if (e.CloseReason == ToolStripDropDownCloseReason.AppClicked)
            if (this.button1.Bounds.Contains(this.PointToClient(MousePosition)))
            {
                td.Tag = true;
                return;
            }
        td.Tag = null;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        if (td.Tag == null)
        {
            td.Show(Cursor.Position);
            td.Tag = true;
        }
        else
        {
            td.Close();
            td.Tag = null;
        }
    }
