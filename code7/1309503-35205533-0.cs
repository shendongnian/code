       void radPropertyGrid1_EditorInitialized(object sender, PropertyGridItemEditorInitializedEventArgs e)
        {
            PropertyGridDropDownListEditor editor = e.Editor as PropertyGridDropDownListEditor;
            if (editor != null)
            {
                editor.DropDownStyle = RadDropDownStyle.DropDownList;
            }
        }
