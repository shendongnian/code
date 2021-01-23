        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0");    
    baglan.Open();    
    string sql = "Select * From [Sayfa1$A1:A100] ";    
    OleDbCommand komut = new OleDbCommand(sql, baglan);    
    OleDbDataReader dr = null;    
    dr = komut.ExecuteReader();
                    DataTable dt = new DataTable();
                dt.Load(dr);
         // To Copy distinct values from specified column to a different datatable
        DataTable diffValues = dt.DefaultView.ToTable(true, "ColName");
        combobox1.DataSource = datatable;
