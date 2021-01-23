    using (var command = <your data provider command>)
    {
        foreach var item in lst.SelectedItems
        {
            var sql = "Insert into tbl (a,b,c) values (. . use your list values here OR parameter names. .)";
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            // preferably - parameterize your command
            command.Parameters.AddWithValue(....); 
            //
            command.ExecuteNonquery();
        }
    }
