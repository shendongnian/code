      private void dgResult_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
          {
            DataGridViewComboBoxEditingControl comboControl = e.Control as DataGridViewComboBoxEditingControl;
            if (comboControl != null)
            {
                //Set the DropDown style to get an editable ComboBox
                if (comboControl.DropDownStyle != ComboBoxStyle.DropDown)
                {
                     
                    comboControl.DropDownStyle = ComboBoxStyle.DropDown;
                    //int r = dgvconn.CurrentRow.Index;
                   
                }
            }
        }
