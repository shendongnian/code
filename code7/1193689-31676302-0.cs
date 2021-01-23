    DataTable tbl = new DataTable();
    using(OleDbConnection c = new OleDbConnection())
    using (OleDbCommand cmd = new OleDbCommand("SELECT * from omed", c))
    {
      c.ConnectionString = "Provider=Microsoft.Ace.Oledb.12.0;Data Source=" + 
         Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Database.accdb";
  
      c.Open();
      OleDbDataReader reader = cmd.ExecuteReader();
      tbl.Load(reader);
      c.Close();
    }
    
    foreach (DataRow r in tbl.Rows)
    {
        DataGridViewRow row = new DataGridViewRow();
        row.CreateCells(dataGridView1);  // this line was missing
        row.Cells[0].Value = r["ID"].ToString();
        row.Cells[1].Value = r["CELL"].ToString();
        row.Cells[2].Value = r["ncc"].ToString();
        row.Cells[3].Value = r["bcchno"].ToString();
        dataGridView1.Rows.Add(row);
        for (int i = 0; i < 31; i++)
        {
            var v = r["n_cell_" + i].ToString();
            row.Cells[i * 3 + 4].Value = v; 
            var resultRow = tbl.AsEnumerable().Last (t => t.Field<string>("CELL").Contains(v));
            row.Cells[i * 3 + 5].Value = resultRow["ncc"].ToString();
            row.Cells[i * 3 + 6].Value = resultRow["bcchno"].ToString();
        }
    }
