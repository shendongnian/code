    var connection = CMASConnectionProvider.Connection;
    var command = new SqlCommand("dbo.test", connection);
    command.CommandType = CommandType.StoredProcedure;
    // Next 2 lines are the point:
    var parameter = command.Parameters.AddWithValue("@tblPASpecs", dtbl); 
    parameter.SqlDbType = SqlDbType.Structured; 
    // Execute the command according your needs and existing helper classes
    // var result = command.Execute();
