    private void button1_Click(object sender, EventArgs e)
    {
        // Getting data from DataGridView
        var list = GetDTfromDGV(dataGridView1);
    }
    private dynamic GetDTfromDGV(DataGridView dgv)
    {
        .....
        .....
        
        var list = dt.AsEnumerable().ToList();
        return list;
    }
