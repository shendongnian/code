    var query = "SELECT * FROM employee_table WHERE imployeeId IN (@ids)";
    var ids = String.Join("," 
                    MyCheckBoxList.Items
                        .Cast<ListItem>()
                        .Where(x => x.Selected)
                        .Select(x => x.Value);
    
    using (var connection = new SqlConnection(myConnectionString))
    {
        connection.Open();
        using(var command = new SqlCommand(query, connection)
        {
            command.Parameters.Add("ids", ids);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                //get all the needed data from the reader
            }
        }
    }
