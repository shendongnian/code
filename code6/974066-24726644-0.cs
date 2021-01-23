    dataGridViewTrial.DataSource = bindingSource;
    // after you are binding your DataGridridView
    // assuming that the UserTypeId Column is at 1st index
    var colUserTypes = this.dataGridViewTrial.Columns[1];
    // by default columns are added as Text columns
    // so we are removing the auto added column
    this.dataGridViewTrial.Columns.Remove(colUserTypes);
    // creating new combobox Column
    var cmbColumn = new DataGridViewComboBoxColumn();
    cmbColumn.DataPropertyName = "UserTypeId";      // this is the property in UserDetails table
    cmbColumn.ValueMember = "UserTypeId";           // this is the property in UserTypes table
    cmbColumn.DisplayMember = "UserTypeName";       // again this property is in UserTypes table
    cmbColumn.DataSource = userTypesBindingSource;  // this binding source is connected with UserTypes table
    this.dataGridViewTrial.Columns.Add(cmbColumn);
