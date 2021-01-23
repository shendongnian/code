    DataGridViewComboBoxColumn cboColUnits = new DataGridViewComboBoxColumn();
    cboColUnits.Items.AddRange(units.ToArray());
    cboColUnits.HeaderText = "Unit";
    cboColUnits.DataPropertyName = "ChosenUnit";
    cboColUnits.DisplayMember = "Name";
    cboColUnits.ValueMember = "Self";
    cboColUnits.ValueType = typeof(Unit);
