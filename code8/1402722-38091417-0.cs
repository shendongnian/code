    private void button3_Click(object sender, EventArgs e)
    {
        var dataView = (DataView)dataGridView1.DataSource;
        var table = dataView.Take(8)              // Since you want only 8 rows
                            .CopyToDataTable();   // Creates new DataTable
      
        Form8 f = new Form8(table); 
        f.Show();
    }
