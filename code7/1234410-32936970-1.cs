    private void ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
    {
        GridView view = sender as GridView;
        if (view.FocusedColumn.FieldName == "COLUMN1")
        {
            if (e.Value is bool)
            {
                GridColumn column = view.GetDataSourceItem<MyClass>(view.FocusedRowHandle);
    
                if (Names.Any(x => x.FieldName == column.FieldName) && !((bool)e.Value))
                {
                    // These 2 lines make errorprovider go crazy
                    view.FocusedColumn.MaxWidth += 50;
                    view.FocusedColumn.Width += 30;
                    view.ShowEditor();
                    view.ActiveEditor.EditValue = e.Value;
                    e.Valid = false;
                    e.ErrorText = "The error";
                }
                else
                {
                    e.Valid = true;
                    view.FocusedColumn.Width -= 30;
                    view.FocusedColumn.MaxWidth -= 50;
                }
            }
            else
            {
                e.Valid = false;
                e.ErrorText = "Invalid value";
            }
        }
    }
