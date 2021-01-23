        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            radGridView1.CellEditorInitialized += RadGridView1_CellEditorInitialized;
        }
        private void RadGridView1_CellEditorInitialized(object sender, GridViewCellEventArgs e)
        {
            RadDropDownListEditor editor = e.ActiveEditor as RadDropDownListEditor;
            if (editor != null)
            {
                RadDropDownListEditorElement ddlElement =(RadDropDownListEditorElement ) editor.EditorElement;
                ddlElement.DropDownMinSize = new Size(200, 300);
            }
        }
