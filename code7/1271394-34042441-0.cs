    using DevExpress.XtraGrid.Views.Grid;
    
    private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e) {
       if (e.Column.FieldName != "ShipCity") return;
       GridView gv = sender as GridView;
       string fieldValue = gv.GetRowCellValue(e.RowHandle,gv.Columns["ShipCountry"]).ToString();
       switch (fieldValue) {
          case "France":
             e.RepositoryItem = repositoryItemComboBox1;
             break;
          case "USA":
             e.RepositoryItem = repositoryItemComboBox2;
             break;
       }
    }
