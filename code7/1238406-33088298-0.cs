    for (int i = 0; i < cbAvailableEntities.Items.Count - 1; i++) {
    SqlConnection connection = new SqlConnection(connString);
    SqlCommand com = new SqlCommand("InsertProjectEntity", connection);
    SqlCommand dcm = new SqlCommand();
    using(connection) {
        //First time going through the loop, i = 0 is true.
        if (i == 0) {
            connection.Open();
            using(com) {
                //This will remove anything in the DB related to the ProjectID being edited.
                dcm.Connection = connection;
                dcm.CommandText = "DELETE FROM [dbo].[ProjectEntity] WHERE ProjectID = " + _pID;
                dcm.ExecuteNonQuery();
                //This will insert all items checked in the checkboxlist but will not insert the unchecked.
                if (cbAvailableEntities.Items[i].Selected) {
                    com.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramPID = new SqlParameter("@ProjectID", nr.ProjectID);
                    com.Parameters.Add(paramPID);
                    nr.Entities = cbAvailableEntities.Items[i].Value;
                    com.Parameters.AddWithValue("@CorpID", nr.Entities);
                    com.ExecuteNonQuery();
                }
            }
        } else {
            connection.Open();
            using(com) {
                //This will insert all items checked in the checkboxlist but will not insert the unchecked.
                if (cbAvailableEntities.Items[i].Selected) {
                    com.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramPID = new SqlParameter("@ProjectID", nr.ProjectID);
                    com.Parameters.Add(paramPID);
                    nr.Entities = cbAvailableEntities.Items[i].Value;
                    com.Parameters.AddWithValue("@CorpID", nr.Entities);
                    com.ExecuteNonQuery();
                }
            }
        }
    }
