            SqlConnection con = new  SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand check = new SqlCommand("select * from fees where admno = @admno", con);          
               SqlDataReader rdr = null;
                rdr = check.ExecuteReader();
             ArrayList  array= new ArrayList();
                while(rdr.Read())
                {
                    array.Add(rdr["tutionfee"].ToString())
                   
                }
