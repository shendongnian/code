    public string Str { get; private set; }
    
    private DataGridViewCell ActiveCell = null;
    private void CopyClick(object sender, EventArgs e)
    {
        if (ActiveCell != null && ActiveCell.Value != null)
        Str = authLeaveView.Rows[ActiveCell.RowIndex].Cells[0].Value.ToString();
        Clipboard.SetText(Str);
        recLeavePop rlp = new recLeavePop();
        rlp.Show();
    }
