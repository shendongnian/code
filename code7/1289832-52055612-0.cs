    string query = textBox1.Text;
    if(query == string.Empty)
    {
        dataTable.DefaultView.RowFilter = string.Empty;
    }
    else
    {
        (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("Name = {0}", textBox1.Text);
        (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("Date = {1}", textBox1.Text);
    }
