    public List<Details> GetData()
    {
        using (SqlConnection con = new SqlConnection(Global.Config.ConnStr))
        {
            
            DataTable dt = new DataTable();
            List<Details> details = new List<string>();
    
            SqlCommand cmd = new SqlCommand("spp_adm_user_user_group_sel", con);
            cmd.CommandType = CommandType.StoredProcedure;
    
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
    
            foreach (DataRow dr in dt.Rows)
            {
               Details group=new Details();
    
                group.Group_name  =dr.Field<string>("Group_name");
                group.fullname =dr.Field<string>("fullname");
                group.designation =dr.Field<string>("designation");
                group.email=dr.Field<string>("email");
                group.mobile=dr.Field<string>("mobile");
    
                details.add(group);
            }
        }
    
        return details;
    }
