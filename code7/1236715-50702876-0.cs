    using (var sqlConnection = new SqlConnection (_connectionString)) {
      sqlConnection.Open ();
      using (var sqlCommand = sqlConnection.CreateCommand ()) {
        sqlCommand.Parameters.Clear ();
        sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
        // YOUR STORED PROCEDURE NAME AND PARAMETERS SHOULD COME HERE
        sqlCommand.CommandText = "sp_InsertData";
        sqlCommand.Parameters.AddWithValue ("@Code", e.Entity.Symbol);
        sqlCommand.Parameters.AddWithValue ("@Name", e.Entity.Name);
        sqlCommand.Parameters.AddWithValue ("@Price", e.Entity.Price);
        try {
          var sqlDataInsert = sqlCommand.ExecuteNonQuery ();                    
        } catch (Exception ex) {
           MessageBox.Show (ex.Message, this.Title);
        }
      }
    }
