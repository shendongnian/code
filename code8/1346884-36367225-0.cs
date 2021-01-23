    using (SqlConnection conn = new SqlConnection(constr))
    {
        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "SELECT * FROM [user]";
            cmd.Connection = conn;
            conn.Open();
            using (SqlDataReader sdr = cmd.ExecuteReader())
            {
                while (sdr.Read())
                {
                    TemplateField fld = new TemplateField();
                    fld.HeaderText = sdr["user_first_name"].ToString();
                    fld.HeaderStyle.Width = Unit.Pixel(80);
                    GridView1.Columns.Add(fld);
                }
            }
            conn.Close();
        }
    }
    ...
    GridView1.DataSource = ...
    GridView1.DataBind();
