    private void gridView_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) 
    {
        if (e.Column.FieldName == "YourField" && e.RowHandle == GridControl.AutoFilterRowHandle)
        {
            e.RepositoryItem = repositoryItemCheckedComboBoxEdit;
        }
    }
