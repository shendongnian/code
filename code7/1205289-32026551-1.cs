        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var combo = ((DataGridView)sender).CurrentCell as DataGridViewComboBoxCell;
            if (combo == null)
            {
                return;
            }
            if (!combo.Items.Contains(e.FormattedValue))
            {
                // Add the text you type into you bound list and refresh binding
                list.Add(e.FormattedValue.ToString());
                DataGridViewComboBoxColumn col = ((DataGridView)sender).CurrentCell.OwningColumn as DataGridViewComboBoxColumn;
                col.Items.Clear();
                col.Items.AddRange(list);
            }
            // Display what you type
            ((DataGridView)sender).CurrentCell.Value = e.FormattedValue;
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox comboControl = e.Control as ComboBox;
            if (comboControl != null)
            {
                if (comboControl.DropDownStyle != ComboBoxStyle.DropDown)
                {
                    comboControl.DropDownStyle = ComboBoxStyle.DropDown;
                }
                //Update Items if list has changed (assumes items can't be deleted)
                if (comboControl.Items.Count != list.Count)
                {
                    DataGridViewComboBoxColumn col = ((DataGridView)sender).CurrentCell.OwningColumn as DataGridViewComboBoxColumn;
                    col.Items.Clear();
                    col.Items.AddRange(list.ToArray());
                    //Note: current cell's items don't appear to be refreshed by the lines above
                    comboControl.Items.Clear();
                    comboControl.Items.AddRange(list.ToArray());
                }
            }
        }
