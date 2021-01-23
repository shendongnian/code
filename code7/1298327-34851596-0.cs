    string name = string.Empty;
    using (var command = new SqlCommand(sql,cnn))
    {
        command.Parameters.Add("@student_no", SqlDbType.VarChar).Value = studentNo;
        object returnValue = Command.ExecuteScalar();
        name = Convert.ToString(returnValue);
    }
