    //text column
    dataGridView1.ColumnCount = 1;
    dataGridView1.Columns[0].Name = "Channel";  // !*!
    dataGridView1.Columns["Channel"].ReadOnly = true;
    dataGridView1.Rows.Add(16);
    for (int i = 1; i <= 16; i++)
    {
        dataGridView1[0, i].Value = i + "";
    }
    ..
