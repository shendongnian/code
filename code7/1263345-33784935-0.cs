    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["Events2"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("spRegistrantsGridView"))
            {
                cmd.CommandType = CommandType.StoredProcedure;  
                // missing parameter
                cmd.Parameters.AddWithValue("@RegistrantId", [insert id]);
                cmd.Parameters.AddWithValue("@Action", "SELECT");
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }   
