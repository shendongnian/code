    DataTable dt = new DataTable();
    dt.Columns.Add("Col 1", typeof(int));
    dt.Rows.Add(1);
    dt.Rows.Add(2);
    dt.Rows.Add(3);
    
    dataGridView1.DataSource = dt;
    
    DataGridViewCheckBoxColumn curCol = new DataGridViewCheckBoxColumn();
    curCol.HeaderText = "Col 2";
    dataGridView1.Columns.Insert(1, curCol);
