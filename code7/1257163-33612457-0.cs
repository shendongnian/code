    using (SqlConnection cn = Common.GetConnection())
    {
      using (SqlCommand cmd = new SqlCommand("[your SQL command here]", cn))
      {
      }
    }
