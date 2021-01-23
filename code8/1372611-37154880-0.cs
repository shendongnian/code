    using (SqlConnection con = new SqlConnection(dc.Con)) {
      using (SqlCommand cmd = new SqlCommand("sp_lightItem", con)) {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = itemId.Text;
        con.Open();
        cmd.ExecuteNonQuery();
      }
    }
