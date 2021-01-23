    protected List<string> Collection()
    {
         List<string> allimage = new List<string>();
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
                         allimage.Add(dr["Image_Path"].ToString());
                     }
                  }
              }
          }
          return allimage;
    }
