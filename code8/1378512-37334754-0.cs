    DataTable table = new DataTable();
    table.Columns.Add("ID", typeof(int));
    table.Columns.Add("Name");
    
    table.Rows.Add(0, "Name 0");
    table.Rows.Add(1, "Name 1");
    table.Rows.Add(2, "Name 2");
    
    checkedListBox1.DataSource = table;
    checkedListBox1.DisplayMember = "Name";
    checkedListBox1.ValueMember = "ID";
    
    checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
    
    private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
        CheckedListBox clb = (CheckedListBox)sender;
        DataRowView row = (DataRowView)clb.Items[e.Index];
        MessageBox.Show(row[clb.ValueMember].ToString());
    }
