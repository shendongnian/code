    private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            string cName = e.Column.FieldName;
            GridView gv = sender as GridView;
            
            if (cName == "CarType.IdApi")
            {
                if (isNewRow)
                {
                    Cars cars= (Cars)gv.GetRow(e.RowHandle);
                               
                    int a = e.RowHandle;
                    if (cars.ID== 0 && e.RowHandle == 0)
                    {
                       e.Column.OptionsColumn.AllowEdit = true;
                    }
                 }        
             }
        }
