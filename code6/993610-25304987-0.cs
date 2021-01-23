    private void button2_Click(object sender, EventArgs e)
    {
        dataGridView1.AllowUserToAddRows = false;
        string[] Files = System.IO.Directory.GetFiles(@"f:\ecet\");
        
        DataTable table = new DataTable();
        table.Columns.Add("Content".ToString());
        foreach (string sFile in Files)
        {
            string fileCont = System.IO.File.ReadAllText(sFile);
            DataRow dr = table.NewRow();
            dr["Content"] = fileCont;
            table.Rows.Add(dr);
        }
        dataGridView1.DataSource = table;
    }
