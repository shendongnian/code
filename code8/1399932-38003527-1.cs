    this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
    {
        ValueType = typeof(decimal),
        Name = "Column1",
        HeaderText = "Column One"
    });
    this.dataGridView1.Columns["Column1"].DefaultCellStyle.Format = "N2";
