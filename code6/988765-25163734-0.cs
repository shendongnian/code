    // 1.  create a command object identifying the stored procedure
    SqlCommand cmd  = new SqlCommand("SelectScore", conn);
    // 2. set the command object so it knows to execute a stored procedure
    cmd.CommandType = CommandType.StoredProcedure;
    // 3. add parameter to command, which will be passed to the stored procedure
    cmd.Parameters.Add(new SqlParameter("@moduleID ", moduleID ));
    // execute the command
    using (SqlDataReader rdr = cmd.ExecuteReader()) {
        // iterate through results, printing each to console
        while (rdr.Read())
        {
            ..
        }
    }
    }
