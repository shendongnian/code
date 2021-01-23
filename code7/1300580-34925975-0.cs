    gridView1.ShownEditor += gridView1_ShownEditor;
    
    private void gridView1_ShownEditor(object sender, EventArgs e) {
        GridView view = (GridView)sender;
        view.ActiveEditor.EditValueChanged += editor_EditValueChanged;
    }
    
    private void editor_EditValueChanged(object sender, EventArgs e) {
        if (!gridView1.FocusedColumn.Name == "col1")
            return;
        gridView1.PostEditor();
        var x = gridView1.GetRowCellValue(e.RowHandler, col1);
        gridView1.SetRowCellValue(e.RowHandler, col2, x);
    }
