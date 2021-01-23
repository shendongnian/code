    var command = new SqlCommand("INSERT INTO MyTable (SomeColumn) VALUES (@SomeColumn)", connection)
    var parameter = command.Parameters.Add("@SomeColumn", SqlDbType.VarChar, 50)
    foreach (var line in myTextBox.Lines)
    {
        parameter.Value = line
        // Execute command here.
    }
