    private void Form1_Load(object sender, EventArgs e)
            {
                MessageBox.Show("sdgds");
                SqlCommand sCommand;
                SqlCommandBuilder sBuilder;
                DataTable sTable;
                string sql = "SELECT * FROM mytable";
                SqlConnection myConnection = new SqlConnection("user id=test;" +
                                           "password=test;server=MOBILE01;" +
                                           "Trusted_Connection=yes;" +
                                           "database=mydatabase; " +
                                           "connection timeout=30");
                myConnection.Open();
    
    
                sCommand = new SqlCommand(sql, myConnection);
                
                /// here is the change - getting data in data reader and filling datatable directly with it.
                var reader = sCommand.ExecuteReader();
                sTable = new DataTable();
                sTable.Load(reader);
                dataGridView1.DataSource = sTable;
                dataGridView1.ReadOnly = true;
    
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                myConnection.Close();
            }
        }
