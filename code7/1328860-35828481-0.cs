    double sum = 0;
    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
    {
        sum += double.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString().Replace(',','.'));
    }
    int count_row = dataGridView1.Rows.Count;
    
    label1.Text = (((int)sum).ToString());
