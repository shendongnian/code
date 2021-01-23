    private enum DataGridViewHitTestTypeInternal
    {
        None,
        Cell,
        ColumnHeader,
        RowHeader,
        ColumnResizeLeft,
        ColumnResizeRight,
        RowResizeTop,
        RowResizeBottom,
        FirstColumnHeaderLeft,
        TopLeftHeader,
        TopLeftHeaderResizeLeft,
        TopLeftHeaderResizeRight,
        TopLeftHeaderResizeTop,
        TopLeftHeaderResizeBottom,
        ColumnHeadersResizeBottom,
        ColumnHeadersResizeTop,
        RowHeadersResizeRight,
        RowHeadersResizeLeft,
        ColumnHeaderLeft,
        ColumnHeaderRight
    }
    void dataGridView1_MouseDown(object sender, MouseEventArgs e)
    {
        var info = this.dataGridView1.HitTest(e.X, e.Y);
        var typeInternal = info.GetType().GetField("typeInternal", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance);
        var value = (DataGridViewHitTestTypeInternal)typeInternal.GetValue(info);
        /* Then decide based on value */
    }
