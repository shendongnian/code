    int sum = 0;
    for (int i = 0; i < dvData.Rows.Count; ++i)
    {
        sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
    }
    label.text = sum.ToString();
