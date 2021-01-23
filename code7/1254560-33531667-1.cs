        string query = "DELETE FROM sprints WHERE [sprint_id]  = @id";
       string ConnectionString = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using(SqlConnection myConnection = new SqlConnection(ConnectionString))
        using(SqlCommand myCommand(query, myConnection))
        {
            myConnection.Open();
            myCommand.Parameters.Add("@id", SqlDbType.NVarWChar).Value = sprintid;
            myCommand.ExecuteNonQuery();
        }
        
