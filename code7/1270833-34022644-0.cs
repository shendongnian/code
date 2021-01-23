    using DevExpress.XtraEditors;
    using DevExpress.XtraGrid.Views.Grid;
    
    private DataView clone = null;
    
    private void gridView1_ShownEditor(object sender, System.EventArgs e) {
        GridView view = sender as GridView;
        if (view.FocusedColumn.FieldName == "CityCode" && view.ActiveEditor is LookUpEdit) {
            Text = view.ActiveEditor.Parent.Name;
            DevExpress.XtraEditors.LookUpEdit edit;
            edit = (LookUpEdit)view.ActiveEditor;
    
            DataTable table = edit.Properties.DataSource as DataTable;
            clone = new DataView(table);
            DataRow row = view.GetDataRow(view.FocusedRowHandle);
            clone.RowFilter = "[CountryCode] = " + row["CountryCode"].ToString();
            edit.Properties.DataSource = clone;
        }
    }
    
    private void gridView1_HiddenEditor(object sender, System.EventArgs e) {
        if (clone != null) {
            clone.Dispose();
            clone = null;
        }
    }
