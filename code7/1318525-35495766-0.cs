    String sql = "select * from Inventory where someColumnName=@foo ORDER BY ROnumber DESC"; 
    using (SqlConnection cn = new SqlConnection("Your connection string here")) 
       {
       using (SqlCommand cmd = new SqlCommand(sql, cn)) 
          {
            cmd.Parameters.Add("@foo", SqlDbType.VarChar, 50).Value = comboRO.Text;
            //execute command here
          }
       }
