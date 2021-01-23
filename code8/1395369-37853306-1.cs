    private IEnumerator<Row> GetRows(SqlConnection connection)
    {
        var resultSet = connection.ExecuteQuery(.....);
        resultSet.Open();
        while(resultSet.FetchNext())
        {
            // read one row..
            yield return row;
        }
        resultSet.Close();
    }
    foreach(var row in GetRows(connection))
    {
        // handle the row.
    }
