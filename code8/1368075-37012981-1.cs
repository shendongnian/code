    using (SqlCommand cmd = new SqlCommand("spUpdateAvailPlaces", con))
    {
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add("@updatedAvailability", SqlDbType.VarChar).Value = updatedAvailability;
      cmd.Parameters.Add("@clocationID", SqlDbType.VarChar).Value = clocationID;
      cmd.Parameters.Add("@cWeekNumber", SqlDbType.VarChar).Value = cWeekNumber;
      con.Open();
      cmd.ExecuteNonQuery();
    }
