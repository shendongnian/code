        /// <summary>
        /// This will trigger all changes to the CheckedState - even unchecking
        /// </summary>
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton checkedRadioButton = (RadioButton) sender;//Cast the sender of the event back to RadioButton
            if (checkedRadioButton.Checked)//Only do this when checking - not on unchecking
            {
               MessageBox.Show(checkedRadioButton.Name, "Pressed"); 
            }
        }  
 
        
