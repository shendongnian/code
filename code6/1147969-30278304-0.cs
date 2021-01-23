    for (int i = 0; i < dataGridView1.Rows.Count; i++)
    {
        string col1 = dataGridView1.Rows[i].Cells[0].Value.ToString();
        string col2 = dataGridView1.Rows[i].Cells[1].Value.ToString();
        string col3 = dataGridView1.Rows[i].Cells[2].Value.ToString();
        string insert_sql = "INSERT INTO Input(UserID, UserName, PassImage) VALUES ('" + col1 + "','" + col2 + "','" + col3 + "')";
        this.getcom(insert_sql);
    }
                                                 
