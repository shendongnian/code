    private void AddComboBox()
        {
            var comboNames = new DataGridViewComboBoxColumn { Name = "cmbNames", HeaderText = "Names" };
            dataGridView.Columns.Add(comboNames);
        }
    private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                if (dataGridView.CurrentCell.ColumnIndex == dataGridView.Columns["cmbNames"].Index)
                {
                    var combo = e.Control as ComboBox;
                    if (combo == null)
                        return;
    
                    combo.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }
