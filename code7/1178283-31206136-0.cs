    //Global variable for adapter;
    DataSet dataSet;
    public void LoadData() {
                string conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db.mdb";
                OleDbConnection connection = new OleDbConnection(conStr);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
    
                connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT * FROM " + 
                    TABLE_NAME, connection); 
    
                connection.Close();
    
                adapter.SelectCommand = command;
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
                
            }
