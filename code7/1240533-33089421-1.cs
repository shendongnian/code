            public void typeColumnDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control.GetType() != typeof (DataGridViewComboBoxEditingControl)) return;
            if (((ComboBox) e.Control).SelectedIndex == 0)
            {
                //If user selected first combobox value "Custom", make control editable
                ((ComboBox) e.Control).DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
                if (((ComboBox) e.Control).DropDownStyle != ComboBoxStyle.DropDown) return;
                //If different value and combobox was set to editable, disable editing
                ((ComboBox) e.Control).DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
