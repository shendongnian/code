    DataTable DT2 = null;
    private void button16_Click(object sender, EventArgs e)
    {
        DT2 = new DataTable("Artists");
        DT2.Columns.Add("Name", typeof(string));
        DT2.Columns.Add("Age", typeof(int));
        DT2.Columns.Add("Score", typeof(int));
        DataRow row = DT2.NewRow();
        row.SetField("Name", "Association");
        row.SetField("Age", 51);
        row.SetField("Score", 99);
        DT2.Rows.Add(row);
        row = DT2.NewRow();
        row.SetField("Name", "Band");
        row.SetField("Age", 23);
        row.SetField("Score", 10);
        DT2.Rows.Add(row);
        row = DT2.NewRow();
        row.SetField("Name", "Cream");
        row.SetField("Age", 43);
        row.SetField("Score", 33);
        DT2.Rows.Add(row);
        dataGridView1.DataSource = DT2;
    }
