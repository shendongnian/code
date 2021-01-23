    private void Form1_Load(object sender, EventArgs e) {
        DataTable dt = InitData();
        listBox1.DataSource = dt;
    }
    
    private static DataTable InitData() {
        DataTable dt = new DataTable();
        dt.Columns.Add("CMM", typeof(int));
        dt.Columns.Add("Location", typeof(int));
        DataRow row = dt.NewRow();
        row["CMM"] = 25;
        row["Location"] = 1;
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["CMM"] = 26;
        row["Location"] = 2;
        dt.Rows.Add(row);
        row = dt.NewRow();
        row["CMM"] = 27;
        row["Location"] = 21;
        dt.Rows.Add(row);
        return dt;
    }
    
    private void listBox1_Format(object sender, ListControlConvertEventArgs e) {
        //We assigned dataTable with DataRows, but e.ListItem is DataRowView ¿?
        DataRowView rowView = e.ListItem as DataRowView;
        if (rowView != null) {
            e.Value = ((int)rowView.Row["Location"] == 2) ? "*" + rowView.Row["CMM"].ToString() : rowView.Row["CMM"];
        }
    }
