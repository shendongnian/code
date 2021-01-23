    settings.KeyFieldName = "Id";
    settings.SettingsEditing.Mode = GridViewEditingMode.Batch;
    settings.SettingsEditing.BatchEditSettings.EditMode = GridViewBatchEditMode.Cell;
   
    //to handle edit events on client side
    **settings.ClientSideEvents.BatchEditStartEditing = "OnBatchStartEdit";**
    settings.CommandColumn.Visible = true;
    settings.CommandColumn.ShowDeleteButton = true;
    settings.CommandColumn.ShowNewButtonInHeader = true;
    
  
    settings.Columns.Add(column =>
    {
        column.FieldName = "Id";
        column.Caption = "ID";
        column.ColumnType = MVCxGridViewColumnType.SpinEdit;
    });
    settings.Columns.Add(column =>
    {
        column.FieldName = "Name";
        column.Caption = "Name";
     
    });
