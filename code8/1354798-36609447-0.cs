        dataGridView1.Columns.Clear();
        dataGridView1.AutoGenerateColumns = false;
        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
        column.DataPropertyName = "Description";
        column.Name = "Description";
        column.HeaderText = "Description";
        column.Width = 150;
        //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        dataGridView1.Columns.Add(column)
        DataGridViewComboBoxColumn ccolumn = new DataGridViewComboBoxColumn();
        ccolumn.DataPropertyName = "cmb";
        ccolumn.Name = "cmb";
        ccolumn.HeaderText = "Cat";
        ccolumn.Width = 65;
        ccolumn.DataSource = ds2;
        ccolumn.DisplayMember = "cat";
        ccolumn.ValueMember = "cat";
        dataGridView1.Columns.Add(ccolumn);
