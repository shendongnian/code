    dataGridView1.ColumnCount = 3;
    for (int i = 0; i < dataGridView1.ColumnCount; i++)
    {
         dataGridView1.Columns[i].Name = "Product ID" + i + "";
    }
     for (int j = 0; j <= 5; j++)
     {
         dataGridView1.Rows.Add();
     }
