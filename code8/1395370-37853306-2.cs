    private IEnumerator<Row> GetRows(SqlConnection connection)
    {
        var resultSet = connection.ExecuteQuery(.....);
        resultSet.Open();
        try
        {
            while(resultSet.FetchNext())
            {
                // read one row..
                yield return row;
            }
        }
        finally
        {
            resultSet.Close();
        }
    }
    foreach(var row in GetRows(connection))
    {
        // handle the row.
    }
