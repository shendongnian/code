    private DataGridViewComboBoxColumn MakeDataGridViewComboBoxColumn(string fieldName, string headerText, DataGridViewColumnSortMode sortMode, bool readOnly)
    {
      DataGridViewComboBoxColumn result = new DataGridViewComboBoxColumn();
      result.Name = fieldName;
      result.DataPropertyName = fieldName;
      result.HeaderText = headerText;
      result.SortMode = sortMode;
      result.ReadOnly = readOnly;
      return result;
    }
