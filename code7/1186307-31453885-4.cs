    private void dataGridView1_EditingControlShowing(object sender,
                 DataGridViewEditingControlShowingEventArgs e)
    {
        theBoxCell = (ComboBox) e.Control;
        theBoxCell.DrawItem += theBoxCell_DrawItem;
        theBoxCell.DrawMode = DrawMode.OwnerDrawVariable;
    }
