    DataTable DT2 = null;
    private void button16_Click(object sender, EventArgs e)
    {
        DT2 = new DataTable("Artists");
        DT2.Columns.Add("Name", typeof(string));
        DT2.Columns.Add("Age", typeof(int));
        DT2.Columns.Add("Score", typeof(int));
        DT2.Rows.Add("Animals", 33, 17);
        DT2.Rows.Add("Band", 45, 9);
        DT2.Rows.Add("Cream", 43, 26);
        DT2.Rows.Add("Doors", 50, 21);
        dataGridView1.DataSource = DT2;
    }
