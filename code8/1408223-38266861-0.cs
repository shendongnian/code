        private void comboWorksheet_SelectionChanged(object sender, EventArgs e)
        {
            dataGridContents.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridContents.DataMember = _contents.Tables[int.Parse(((ComboBox)sender).SelectedValue.ToString())].TableName;
        }
        private void dataGridContents_DataMemberChanged(object sender, EventArgs e)
        {
            dataGridContents.SetColumnSortMode(DataGridViewColumnSortMode.NotSortable);
            dataGridContents.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }
