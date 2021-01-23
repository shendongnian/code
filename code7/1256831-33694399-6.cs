    protected IEnumerable<string> Collection()
    {
         string address = ConfigurationManager.ConnectionStrings["blogconnection"].ToString();
         using (SqlConnection con = new SqlConnection(address))
         {
             con.Open();
             string qry = "select * from images";
             SqlCommand cmd = new SqlCommand(qry, con);
             using (SqlDataReader dr = cmd.ExecuteReader())
             {
                 if (!dr.HasRows) return allimage;
                 while (dr.Read())
                 {
                     if (!string.IsNullOrEmpty(Convert.ToString(dr["Image_Path"])))
                     {
                         yield return (dr["Image_Path"].ToString());
                     }
                  }
              }
          }
    }
