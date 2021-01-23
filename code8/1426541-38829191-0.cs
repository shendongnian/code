        settings.Columns.Add(col =>
        {
            col.FieldName = "Id";
            col.Caption = "Id";
            col.SetEditItemTemplateContent(e =>
            {
                if (e.Grid.IsNewRowEditing)
                {
                    // your code here
                }
                else
                {
                    // your code here
                }
            });
        });
