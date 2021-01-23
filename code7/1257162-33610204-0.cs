    using (SqlConnection connection = new SqlConnection(...))
    {
      connection.Open();
      using (SqlCommand cmd = new SqlCommand("....", connection))
      {
      }
    }
