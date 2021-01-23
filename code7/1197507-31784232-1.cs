    // It's not helper that owns SqlConnection
    using (SqlConnection con = new SqlConnection(...)) {
      ...
      Helper helper = new Helper() {
        SqlConnection = con; 
      };
      
      ...
    }
