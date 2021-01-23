    DataSet ds = new DataSet();
    ds.Tables.Add(GetData(GetConnectionString(conStringBlm), CmdStrBlm));
    //... do this for each connection string 
    DataTable dtAll = ds.Tables[0].Copy();
            for (var i = 1; i < ds.Tables.Count; i++)
            {
                dtAll.Merge(ds.Tables[i]);
            }
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dtAll;
