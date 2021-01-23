    var col = new DataGridViewComboBoxColumn();
    col.Name = "PeopleName";
    col.DataPropertyName = "PeopleName";   // The DataTable column name.
    col.HeaderText = "Name";
    col.DataSource = people;
    col.DisplayMember = "Name";
    col.ValueMember = "Name";              // People.Property matching the DT column.
    this.dataGridView1.Columns.Add(col);
    this.dataGridView1.DataSource = table;
    this.dataGridView1.Columns[1].HeaderText = "Phone";
