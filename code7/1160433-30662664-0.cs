    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        var width = ClientRectangle.Width / 2;
        clientTableDataGridView.Left = 0;
        clientTableDataGridView.Width = width;
        clientHistoryTableDataGridView.Left = width;
        clientHistoryTableDataGridView.Width = width;
    }
