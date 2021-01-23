    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {   
        string query = "INSERT INTO TypeCurves([Entity],[Date],[Value])VALUES(@Entity,@Date,@Value)";
        OleDbCommand myAccessCommand = new OleDbCommand(query, connection);
        myAccessCommand.Parameters.AddWithValue("@Entity", model.CDFResults[i].catname_db);
        myAccessCommand.Parameters.AddWithValue("@Date", model.CDFResults[i].DataPoints[j].dt);
        myAccessCommand.Parameters.AddWithValue("@Value", model.CDFResults[i].DataPoints[j].CDFVal);
        connection.Open();
        myAccessCommand.ExecuteNonQuery();
    }
