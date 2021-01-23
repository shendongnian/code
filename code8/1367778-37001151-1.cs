     DataSet dataset2;
     public void input_sql(string query)
     {
         try
         {
           //open connection
             if (this.OpenConnection() == true)
             {
                 //create command and assign the query and connection from the constructor
                 MySqlCommand cmd = new MySqlCommand(query, connection);
                 //Execute command
                 int x = cmd.ExecuteNonQuery();
                  //close connection
                 this.CloseConnection();
             }
         }
         catch(MySqlException myex) 
         {
                   MessageBox.Show(ex.Message);
         }
     }
     ///////////////////////////////////////////////
     /////  select 
     /////////////////////////////////////////////
     public DataSet output_sql(string query,String table_name)
     {
        
             //Open connection
             this.OpenConnection();
             DataSet dataset = new DataSet();
             MySqlDataAdapter adapter = new MySqlDataAdapter();
             adapter.SelectCommand = new MySqlCommand(query, connection);
             adapter.Fill(dataset, table_name);
			//close Connection
             this.CloseConnection();
             //return list to be displayed
         return dataset;
     }
    }
