    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        //your code....
         var cmbBx = e.Control as DataGridViewComboBoxEditingControl; // or your combobox control
         if (cmbBx != null)
         {
             // Fix the black background on the drop down menu
             e.CellStyle.BackColor = this.dgvSummary.DefaultCellStyle.BackColor;
         }
    }
