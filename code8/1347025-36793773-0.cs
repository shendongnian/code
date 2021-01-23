     public void fill()
        {
            SqlDataAdapter adp = new SqlDataAdapter("select top 10 Question,Option1,Option2,Option3,Option4 from Questions", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }
