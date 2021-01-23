         private void FilterCombobox(ComboBox cmb, string columnName)
        {
            //because the itemsSource of the comboboxes are datatables, filtering is not supported. Converting the itemsSource to a
            //dataview will allow the functionality of filtering to be implemented
            DataView view = (DataView)cmb.ItemsSource;
            view.RowFilter = (columnName + " like '*" + cmb.Text + "*'");
            cmb.ItemsSource = view;
            cmb.IsDropDownOpen = true;
        }
        private void cmbRigNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Down & e.Key != Key.Up) 
            {
                e.Handled = true;
                FilterCombobox(cmbRigNum, "RigNumber");
            }
        }
