    var table = new DataTable();
    table.Columns.Add("Column1", typeof(int));
    table.Columns.Add("Column2", typeof(int));
    table.Columns.Add("Column3", typeof(string));
    table.Rows.Add(1, 2, "1st");
    table.Rows.Add(2, 1, "2nd");
    table.Rows.Add(1, 3, "3rd");
    table.Rows.Add(3, 1, "4th");
    var bs1 = new BindingSource() { DataSource = table };
    this.dataGridView1.DataSource = bs1;
    var view = new DataView(table, "Column1 > Column2",
        "", DataViewRowState.CurrentRows).ToTable(false, "Column3");
    var bs2 = new BindingSource() { DataSource = view };
    this.dataGridView2.DataSource = bs2;
