    Decimal sum = 0;
    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
    {
    sum += Convert.Decimal(dataGridView1.Rows[i].Cells[1].Value);
    }
    int count_row = dataGridView1.Rows.Count;
    
    label1.Text = (sum.ToString());
