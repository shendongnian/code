    Psuedo-code
    string sqlStatement = "INSERT INTO Tab1 VALUES {0},{1},{2}";
    StringBuilder sqlBatch = new StringBuilder();
    foreach(DataRow row in myDataTable)
    {
        sqlBatch.AppendLine(string.Format(sqlStatement, row["Field1"], row["Field2"], row["Field3"]));
        sqlBatch.Append(";");
    }
    myOdbcConnection.ExecuteSql(sqlBatch.ToString());
