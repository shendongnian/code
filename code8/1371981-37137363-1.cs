    private void BindGrid()
    {
        object id = Session["Id"];
        if(id != null)
        {
            user = Session["user"] as User;
        }
        string constr = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        using(SqlConnection con = new SqlConnection(constr))
        {
            string query = "select Conferences.conferenceName , Conferences.conferencePlace , Conferences.conferenceDate , Conferences.category from Conferences inner join Users on Conferences.fk_Users = Users.Id where Users.Id =@Id";
            using(SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Id", user == null ? (object)DBNull.Value : (object)user.UserId);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();                    
                con.Close();
            }
        }
    }
