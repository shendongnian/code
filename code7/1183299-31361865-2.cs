    DataGridViewComboBoxColumn cbcol = new DataGridViewComboBoxColumn ();
    cbcol.Name             = "Account_Status" ;
    cbcol.DataPropertyName = "Account Status" ; // DataTable column name
    cbcol.DataSource       =  ...             ; // ComboBox DataSource
    dataGridViewAP.Columns.Add(cbcol);
    dataGridViewAP.DataSource = DBConn.getAdminInfo();
   
