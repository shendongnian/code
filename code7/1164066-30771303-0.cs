    //you may put this as a direct string or in a static class when layering
    //you can pass table as hard-coded value or as a parameter
    String SqlQuery = "UPDATE " +
                " [tableName] " +
                " SET [Column1ToBeUpdated]=@Column1Value," +
                " [Column2ToBeUpdated]=@Column2Value" +
                " WHERE ([ColumnxWithCondition] = @Condition)";
    //add OR, AND operators as per your needs
    //choose the correct SqlDbType for your column data types
    public bool UpdateMyTable(String SqlQuery, Someclass obj)
     {
            SqlCommand sCommand = new SqlCommand(this.SqlQuery, (new SqlConnection(ConnectionString)));
            sCommand.Parameters.Add("@Column1Value", SqlDbType.VarChar).Value = obj.col1Value;
            sCommand.Parameters.Add("@Column2Value", SqlDbType.VarChar).Value = obj.col2Value;
            sCommand.Parameters.Add("@Condition", SqlDbType.VarChar).Value = obj.condition;
            sCommand.Connection.Open();
            var rowsAffected = sCommand.ExecuteNonQuery();
            sCommand.Connection.Close();
            return rowsAffected > 0;
     }
     //if you want to see the number, you may return rowsAffected
