    DataGridViewColumn auto // = ... auto-generated column to be replaced
    DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
    combo.DataPropertyName = auto.DataPropertyName;
    combo.Name = auto.Name;
    DataGridView dgv = auto.DataGridView;
    dgv.Columns.Add(combo);
    combo.DataSource = GetBookContributorTypes; // collection of comboBox entries
    combo.ValueMember = "BookContributorTypeId";
    combo.DisplayMember = "BookContributorTypeDescription";
    // adopt further properties if required
    combo.Frozen = auto.Frozen;
    combo.DisplayIndex = auto.DisplayIndex;
    combo.Visible = auto.Visible;
    combo.ReadOnly = auto.ReadOnly;
    combo.HeaderText = auto.HeaderText;
    combo.HeaderCell.ToolTipText = auto.HeaderCell.ToolTipText;
    combo.SortMode = auto.SortMode;
    combo.Width = auto.Width;
    dgv.Columns.Remove(auto);
