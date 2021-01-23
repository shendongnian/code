    private void gridLookUpEdit_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
    {
        GridLookUpEdit edit = sender as GridLookUpEdit;
        int theIndex = edit.Properties.GetIndexByKeyValue(edit.EditValue);
        if (theIndex >= 0)
        {
            DataRowView row = (DataRowView)edit.Properties.GetRowByKeyValue(edit.EditValue);
            e.DisplayText = row[0].ToString() + ":    " + row[1].ToString() + " " + row[2].ToString();
        }
    }
