    // Loop through rows and get each combobox
    foreach (DataGridViewRow row in dgv_ClientDetail.Rows)
    {
         DataGridViewComboBoxCell ContactCombo = (DataGridViewComboBoxCell)(row.Cells[index of Contact column]);
         
         ContactCombo.DataSource = // your contacts datasource;
         ContactCombo.DisplayMember = "name of field to be displayed like say ContactName";
    }
     
