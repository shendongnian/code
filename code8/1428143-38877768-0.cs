    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);
        EditingControlValueChanged = true;
        EditingControlDataGridView.NotifyCurrentCellDirty(true);
    }
