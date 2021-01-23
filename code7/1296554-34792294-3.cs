    public List<SomeComplexItem> showAllActiveData()
    {
        List<SomeComplexItem> active = new List<SomeComplexItem>();
        using (sqlConnection = getSqlConnection())
        {
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdShowEmployees;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var someComplexItem = new SomeComplexItem();
                someComplexItem.SomeColumnValue = reader[1].ToString();
                someComplexItem.SomeColumnValue2 = reader[2].ToString();
                someComplexItem.SomeColumnValue3 = reader[3].ToString();
                active.Add(someComplexItem);
            }
            return active;
        }
