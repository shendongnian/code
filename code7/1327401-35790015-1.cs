    private void listView1_DrawColumnHeader(object sender, 
                                            DrawListViewColumnHeaderEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            e.DrawBackground();
            bool value = false;
            try
            {
                value = Convert.ToBoolean(e.Header.Tag);
            }
            catch (Exception)
            {
            }
            CheckBoxRenderer.DrawCheckBox(e.Graphics, 
                new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal :
                System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
        }
        else
        {
            e.DrawDefault = true;
        }
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (e.Column == 0)
        {
            bool value = false;
            try
            {
                value = Convert.ToBoolean(this.listView1.Columns[e.Column].Tag);
            }
            catch (Exception)
            {
            }
            this.listView1.Columns[e.Column].Tag = !value;
            foreach (ListViewItem item in this.listView1.Items)
                item.Checked = !value;
            this.listView1.Invalidate();
        }
    }
