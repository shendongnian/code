     public List<Object> GetData() {
    using (SqlConnection con = new SqlConnection(Global.Config.ConnStr))
            {
                
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("spp_adm_user_user_group_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
        
                
            var result = from o in dt.AsENumerable()
                         select (new
                         {
                            Group_name  =dr.Field<string>("Group_name"),
                            fullname =dr.Field<string>("fullname"),
                            designation =dr.Field<string>("designation"),
                            email=dr.Field<string>("email"),
                            mobile=dr.Field<string>("mobile")
                         } as Object);
        
            }
       
            return result.ToList();
        }
