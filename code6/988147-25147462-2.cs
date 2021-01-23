     using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
     using (SqlDataAdapter da = new SqlDataAdapter("SELECT <USER> FROM <User_Roles> WHERE <USER> = @User AND <ROLE> = @Role", conn))
        {
        da.SelectCommand.Parameters.Add("@User", SqlDbType.VarChar).Value = HttpContext.Current.User.Identity.Name;
        da.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar).Value = "Admin";
             DataSet ds = new DataSet();
             da.Fill(ds);
             if (ds.Tables[0].Rows.Count > 0)
             {
                      //Make things available          
             }
             else
             {
                      //Make things unavailable or hidden         
             }
        }
