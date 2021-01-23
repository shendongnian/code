    String SName=txtBox1.Text;
    
    String sql="select id from student where name = @paramName";
    
    SqlConnection connection = null;
    SqlDataReader reader = null;
    try
    {
        connection = GetConnection();
        SqlCommand command = new SqlCommand(sql, connection);
        SqlParameter param = new SqlParameter("@paramName", SqlDbType.NVarChar, 50);
        param.Value = SName;
        command .Parameters.Add(param);
        if (_sqltransection != null)
        {
            command.Transaction = _sqltransection;
        }
        reader = command.ExecuteReader(CommandBehavior.CloseConnection);
    }            
    catch (SqlException ex)
    {
        throw new DBException(ex);
    }
