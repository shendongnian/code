    private void kodeSatuanList()//this one
    {
        Connection.sqlConnection.Close();
                Connection.Connector(server, database, user, password);
    
    
        adapterKodeSatuan = new SqlDataAdapter("SELECT ID,KOSAT,KETERANGAN FROM KOSAT", Connection.sqlConnection);
        dataTableKodeSatuan.Clear();
        dataGridView1.ClearSelection();
        adapterKodeSatuan.Fill(dataTableKodeSatuan);
        dataViewKodeSatuan = dataTableKodeSatuan.DefaultView;
    
        dataGridView1.ColumnCount = 3;
        
        dataGridView1.Columns[0].Name = "id";
        dataGridView1.Columns[0].HeaderText = "id";
        dataGridView1.Columns[0].DataPropertyName = "id";
    
        dataGridView1.Columns[1].Name = "Kode";
        dataGridView1.Columns[1].HeaderText = "Kode";
        dataGridView1.Columns[1].DataPropertyName = "kosat";
    
        dataGridView1.Columns[2].HeaderText = "Keterangan";
        dataGridView1.Columns[2].Name = "Keterangan";
        dataGridView1.Columns[2].DataPropertyName = "keterangan";
    
        dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic;
        dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.Automatic;
    
        dataGridView1.DataSource = dataViewKodeSatuan;
        Console.WriteLine("dataGridView1.Rows.Count = " + dataGridView1.Rows.Count);
        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
    
        dataGridView1.Columns[0].Visible = false; //this..column id, i set it false..
    }   
