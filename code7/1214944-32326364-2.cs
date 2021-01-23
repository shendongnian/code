    public override void InitializeEditingControl(int rowIndex, object
    	initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
    {
    	base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
    	var ctl = DataGridView.EditingControl as TreeComboBoxEditingControl;
    	ctl.SetItems(Items);
    	ctl.SelectedNode = initialFormattedValue != null ? ctl.AllNodes.FirstOrDefault(x => Equals(x.Tag, initialFormattedValue)) : null;
    	ctl.SelectedNodeChanged += Ctl_SelectedNodeChanged;
    }
