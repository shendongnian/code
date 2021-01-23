    SqlConnection sqlConnection = new SqlConnection(ConnString))
    SqlCommand sqlCommand = new SqlCommand()
    sqlCommand.Connection = sqlConnection;
    sqlConnection.Open();
                
    for(int i=0; i< myDataGridView.Rows.Count;i++)
    {
           query= @"INSERT INTO tableName VALUES (" 
    	          + ddlConsumidorFinalId.SelectedValue + ", "
                  + myDataGridView.Rows[i].Cells["ColumnName"].Value +", " 
                  + myDataGridView.Rows[i].Cells["ColumnName"].Value +");";
    					//Add as pre table fields
                  sqlCommand.CommandText = query;
                  sqlCommand.ExecuteNonQuery();
    }
