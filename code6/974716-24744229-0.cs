	DataTable masterdbdataset = new DataTable();
	//Perform custom operations here if necessary
        BindingSource bSource = new BindingSource();
        for (int i = 0; i < dataGridView2.Rows.Count; i++ )
        {
            if (dataGridView2.Rows[i].Cells[1].Value != null)
            {
                if ((Boolean)dataGridView2.Rows[i].Cells[1].Value == true)
                {
                    try
                    {
                        string myConnection="datasource=localhost;database=dmrc;port=3306;username=root;password=root";
                        MySqlConnection myConn = new MySqlConnection(myConnection);
                        string query = "select * from dmrc." + dataGridView2.Rows[i].Cells[0].Value.ToString();
                        MySqlCommand cmdDatabas = new MySqlCommand(query, myConn);
                        MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
                        myDataAdapter.SelectCommand = cmdDatabas;
                        DataTable dbdataset = new DataTable();
		                myDataAdapter.Fill(dbdataset);
                        myDataAdapter.Update(dbdataset);
			            masterdbdataset.Merge(dbdataset);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
	}
        bSource.DataSource = masterdbdataset;
        f1.dataGridView1.DataSource = bSource;
        f1.Show();
