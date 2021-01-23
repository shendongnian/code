    private void gvBobin_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
    {
        if (e.Column.FieldName == "CHECK")
        {
            bool check_ = (bool)e.Value;
            
            if (check_)//There are no need to write check_ == True
            //You can use e.RowHandle with gvBobin.GetRowCellValue method to get other row values.
            //Example: object value = gvBobin.GetRowCellValue(e.RowHandle,"YourColumnName")
            {
                //...............
            }
            else
            {
                //...............
            }
        }
    }
