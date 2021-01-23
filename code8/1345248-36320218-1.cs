     m_definitions = new BindingList<TagSimDefinition>(TagSimDefinition.Read(e));
     dgvTagNames.Columns.Clear();
     DataGridViewCell cell = new DataGridViewTextBoxCell();
     DataGridViewTextBoxColumn colTagName = new DataGridViewTextBoxColumn()
     {
        CellTemplate = cell,
        Name = "colTagName",
        HeaderText = "Tag Name",
        DataPropertyName = "Name"
     };
    dgvTagNames.Columns.Add(colTagName);
    dgvRegion.Rows.Clear();
    int index = 0;
    foreach (var dparam in m_definitions)
    {
	    dgvTagNames.Rows.Add();
	    dgvTagNames["colTagName", index].Value = dparam.<Property1>;	                                       
	    dgvTagNames.Rows[index].Tag = dparam;
	    index++;
    }
