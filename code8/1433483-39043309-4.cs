    private void showtip(object sender, EventArgs e)
    {
        Point pt = tableLayoutPanel1.PointToClient(Control.MousePosition);
        TableLayoutPanelCellPosition pos = GetCellPosition(tableLayoutPanel1, pt);
        Control c = tableLayoutPanel1.GetControlFromPosition(pos.Column, pos.Row);
        if (c != null && c.Controls.Count > 0)
        {
            toolTip1.Show(c.Controls[0].Text, tableLayoutPanel1, pt, 500);
        }
    }
