    public void context_menu_click(object sender, EventArgs e)
    {
        /*
            Other event and
            printing .txt file from DataGridView
        */
        var item = sender as ToolStripItem  ;
        if (item != null)
        {
            DataGridView gv = item.Tag as DataGridView;
            Console.WriteLine(gv.Name);
        }
    }
    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripItem insert = menu.Items.Add("insert");
            insert.Tag = sender;
            insert.Click += new EventHandler(context_menu_click);
            menu.Show(this.dataGridView1.PointToScreen(new Point(e.X, e.Y)));
        }
    }
