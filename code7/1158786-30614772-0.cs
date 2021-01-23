    SqlCommand query = new SqlCommand();
    query.Connection = ...
    // Parameters start with @
    string queryString = "UPDATE user_info SET user_next_visit_date = @someDateVar WHERE user_id=@userid";
    query.CommandText = queryString;
    // Date parameter
    SqlParameter dtPar = new SqlParameter("@someDateVar", SqlDbType.DateTime, 0);
    dtPar.Value = DateTime.Now; // or any DateTime you have
    query.Parameters.Add(dtPar);
    // Id parameter
    SqlParameter idPar = new SqlParameter("@userId", SqlDbType.Int, 0);
    idPar.Value = user_id;
    query.Parameters.Add(idPar);
    // Execute
    query.ExecuteNonQuery();
