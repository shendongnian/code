    private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
    {
       string valid = gridView.GetRowCellValue(e.RowHandle, "isValid").ToString().ToLower();
       if(valid == "true") 
          e.Appearance.BackColor = Color.Red;
    }
