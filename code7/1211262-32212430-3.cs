    async Task GetMyData( DateTime fromDate, DateTime toDate, int challenge, params int[ ] emloyeeIds )
    {
      using ( var connection = new SqlConnection( "my connection string" ) )
      {
        using ( var command = connection.CreateCommand( ) )
        {
          //--> set up command basics...
          command.CommandText = @"
            select 
              given_id, name, message, emplid, category, created_date 
            from 
              GetMyTable( @from, @to, @challenge, @employeeIds )";
          command.CommandType = System.Data.CommandType.Text;
          //--> easy parameters...
          command.Parameters.AddWithValue( "@from", fromDate );
          command.Parameters.AddWithValue( "@to", toDate );
          command.Parameters.AddWithValue( "@challenge", challenge );
          //--> table-valued parameter...
          var table = new DataTable( "EmployeeIds" );
          table.Columns.Add( "Od", typeof( int ) );
          foreach ( var Id in emloyeeIds ) table.Rows.Add( Id );
          var employeeIdsParameter = new SqlParameter( "@employeeIds", SqlDbType.Structured );
          employeeIdsParameter.TypeName = "dbo.IntIdsType";
          employeeIdsParameter.Value = table;
          command.Parameters.Add( employeeIdsParameter );
          //--> do the work...
          using ( var reader = await command.ExecuteReaderAsync( ) )
          {
            while ( await reader.ReadAsync( ) )
            {
              //...
            }
          }
        }
      }
    }
