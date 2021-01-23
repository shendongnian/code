    string sql = "select * from user_tbl where emp_id = ? and birthdate = ?";
    using (var connection = new OdbcConnection(...))
    {
        connection.Open();
        using (var command = new OdbcCommand(sql, connection))
        {
            command.Parameters.Add("@emp_id", OdbcType.Int).Value = userValidate.EmployeeId;
            command.Parameters.Add("@birthdate", OdbcType.Date).Value = userValidate.BirthDate;
            using (var reader = command.ExecuteReader())
            {
                // Use the reader here
            }
        }
    }
