     private void Form56_Load(object sender, EventArgs e)
            {
              
    
                try
                {
                    MySqlConnection cnn = new MySqlConnection("MY CONNECTION");
               
                    cnn.Open();
                    // - DEBUG 
                    // MessageBox.Show("Connection successful!"); 
                    MySqlDataAdapter MyDA = new MySqlDataAdapter();
                    MyDA.SelectCommand = new MySqlCommand("MY QUERY", cnn);
                    DataTable table = new DataTable();
                    MyDA.Fill(table);
    
                    BindingSource bSource = new BindingSource();
                    bSource.DataSource = table;
    
                    dataGridView1.DataSource = bSource;
    
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
    
            }
