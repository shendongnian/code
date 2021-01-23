    public void nameCSV()
    {
        var reader = new StreamReader(File.OpenRead(@"C:\temp\nameList.csv"));
        
        DataTable tbl = new DataTable();
        tbl.Columns.Add("Name", typeof(string));
        tbl.Columns.Add("ID", typeof(string));
 
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');
            
            DataRow row = tbl.NewRow();
            row["Name"]=values[0];
            row["ID"] = values[1];
            tbl.Rows.Add(row);
        }
        
        cmbxName.DisplayMember = "Name";
        cmbxName.ValueMember = "ID";
        cmbxName.DataSource = tbl;
        
    }
