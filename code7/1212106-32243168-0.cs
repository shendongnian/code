    using DevExpress.XtraGrid.Views.Grid;
    //...
    void gridView_RowStyle(object sender, RowStyleEventArgs e) {
       GridView view = sender as GridView;
       if(e.RowHandle >= 0) {
          int value = (int)view.GetRowCellValue(e.RowHandle, view.Columns["ISVERIFIKASI"]);
          if(value == 1) 
             e.Appearance.Font = ...;
       }
    }
