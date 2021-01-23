    DataTable dt = new DataTable();
    dt.Columns.Add("Column1");
    dt.Columns.Add("Column2");
    
    dt.Rows.Add("1", "5");
    dt.Rows.Add("2", "6");
    dt.Rows.Add("3", "7");
    dt.Rows.Add("4", "8");
    
    dataGridView1.DataSource = dt;
