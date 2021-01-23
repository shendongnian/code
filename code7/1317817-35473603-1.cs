    using (var command = <your data provider command>)
    {
        command.CommandType = CommandType.Text;
        // preferably - parameterize your command
        command.Parameters.Add(....); 
        . . . . . . . .
        //
        foreach (var item in lst.SelectedItems)
        {
            var sql = "Insert into tbl (a,b,c) values (. . use your list values here OR parameter names. .)";
            command.CommandText = sql;
            // if parameterizing 
            command.Parameters[name/index].Value = (....); 
            // ---
            command.ExecuteNonquery();
            
        }
    }
