     protected void Page_Load(object sender, EventArgs e)
        {
          if(!page.Ispostback)
           {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@pid", Request.QueryString["perid"]));
            SqlDataReader reader = SqlHelper.ExecuteReader(connection, "get_person_to_update", parameters.ToArray());
            while (reader.Read()) 
            {
                fname.Text = reader["fname"].ToString();
                mname.Text = reader["mname"].ToString();
                lname.Text = reader["lname"].ToString();
                qualifier.Text = reader["qualifier"].ToString();
                alias_.Text = reader["alias"].ToString();
                address.Text = reader["address"].ToString();
                statussuspect.SelectedIndex = -1;
                statussuspect.SelectedValue = reader["status_of_suspect"].ToString();
            }
        }
   }
