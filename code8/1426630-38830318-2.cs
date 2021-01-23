    string SQL = "SELECT * FROM Sample";
    
    using (MySqlConnection dbCon = new MySqlConnection(MySQLConnStr))
    {
        dtSample = new DataTable();
    
        daSample = new MySqlDataAdapter(SQL, dbCon);          
        daSample.FillSchema(dtSample, SchemaType.Source);
        dbCon.Open();
    
        int Rows = daSample.Fill((page*pageSize), pageSize, dtSample);
    }
    
    dgv2.DataSource = dtSample;
    this.lblPages.Text = String.Format("Rows {0} - {1}",
                             ((page * pageSize) + 1),
                             (page + 1 * pageSize));
