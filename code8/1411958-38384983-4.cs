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
    protected override void OnMouseDown(MouseEventArgs e)
    {
        var info = this.HitTest(e.X, e.Y);
        var typeInternal = info.GetType().GetField("typeInternal", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance);
        var value = (DataGridViewHitTestTypeInternal)typeInternal.GetValue(info);
        /* Then decide based on value */
        // Rest of logic
        base.OnMouseDown(e);    
    }
