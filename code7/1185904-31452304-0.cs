    DataTable dtCards;
    dtCards = new DataTable();
    dtCards.Columns.Add("printedString");
    dtCards.Columns.Add("comboboxValue", typeof(String)); //adding column for combobox
    dtCards.Rows.Add("1", "real");
    dtCards.Rows.Add("2", "real");
    dtCards.Rows.Add("3", "real");
    dtCards.Rows.Add("4", "real");
    
    DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
    cmb.HeaderText = "Select Data";
    cmb.Name = "cmb";
    cmb.MaxDropDownItems = 2;
    cmb.Items.Add("real");
    cmb.Items.Add("sham");
    cmb.DataPropertyName = "comboboxValue"; //Bound value to the datasource
    dataGridView1.Columns.Add(cmb);
    dataGridView1.DataSource = dtCards;
