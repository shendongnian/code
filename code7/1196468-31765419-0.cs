        void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataGridView1.CurrentCell.ColumnIndex == this.DataGridViewComboBoxColumn.Index)
            {
                BindingSource bindingSource = this.dataGridView1.DataSource as BindingSource;
                XYZ xyz = bindingSource.Current as XYZ;
                BindingList<Type> bindingList = this.add_all_data_sets_which_can_be_chosen();
                DataGridViewComboBoxEditingControl comboBox = e.Control as DataGridViewComboBoxEditingControl;
                comboBox.DataSource = bindingList;
                if (xyz.TypeCode != null)
                {
                    comboBox.SelectedValue = xyz.TypeCode;
                }
                else
                {
                    comboBox.SelectedValue = string.Empty;
                }
                comboBox.SelectionChangeCommitted -= this.comboBox_SelectionChangeCommitted;
                comboBox.SelectionChangeCommitted += this.comboBox_SelectionChangeCommitted;
            }
        }
        void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.dataGridView1.EndEdit();
        }
