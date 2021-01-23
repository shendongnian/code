    private void gridControl1_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        TBGRNo.Text = gridControl1.GetFocusedRowCellValue("GRNo").ToString();
        TBSName.Text = gridControl1.GetFocusedRowCellValue("SName").ToString();
        TBFName.Text = gridControl1.GetFocusedRowCellValue("FName").ToString();    
    }
