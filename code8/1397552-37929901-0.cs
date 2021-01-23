    using (var connection = new SqlConnection("MyConnectionstring"))
    {
        connection.Open();
    
        // Create data adapter with the specified SelectCommand
        var adapter = new SqlDataAdapter("select * from Student", connection);
    
        // Build InsertCommand    
        var insertCommand = new SqlCommand(
            "insert into Student (Name) values (@Name) SET @Id = SCOPE_IDENTITY()", 
            connection);
        insertCommand.Parameters.Add("@Name", SqlDbType.VarChar, 20, "Name");
        var parameter = insertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "StudentId");
        parameter.Direction = ParameterDirection.Output;
        insertCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
        adapter.InsertCommand = insertCommand;
    
        // Auto build outher commands
        var builder = new SqlCommandBuilder(adapter);
    
        // Read the data
        var dt = new DataTable();
        adapter.Fill(dt);
    
        // Insert a new record
        var row = dt.NewRow();
        row["Name"] = "Abc";
        dt.Rows.Add(row);
    
        adapter.Update(dt);
    
        // Update the just inserted record
        row["Name"] = "Pqr";
        adapter.Update(dt);
    
        connection.Close();
    }  
