    public List<GroupUserList> GetData()
        {
            DataTable dt = new DataTable();
            List<GroupUserList> details = new List<GroupUserList>();
            using (SqlConnection con = new SqlConnection(Global.Config.ConnStr))
            {
                SqlCommand cmd = new SqlCommand("spp_adm_user_user_group_sel", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach(DataRow dr in dt.Rows)
                {
                    GroupUserList usr = new GroupUserList();
                    usr.name = dr["Group_Name"].ToString();
                    usr.fullname = dr["fullname"].ToString();
                    usr.designation = dr["designation"].ToString();
                    usr.mobile = dr["mobile"].ToString();
                    usr.email = dr["email"].ToString();
                    
                    details.Add(usr);
                }
                
                return details;
            }
        }
