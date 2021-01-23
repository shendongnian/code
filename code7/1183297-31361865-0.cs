    DataGridViewComboBoxColumn cbcol = new DataGridViewComboBoxColumn ();
    cbcol.Name             = "Account_Status" ;
    cbcol.DataPropertyName = "Account Status" ; // DataTable column name
    col1.DataSource =                         ; // ComboBox DataSource
    dataGridViewAP.Columns.Add(col1);
    dataGridViewAP.DataSource = DBConn.getAdminInfo();
   
