    private void Edit_Load(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(str))
        {
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("SELECT Name,Id FROM Companies", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
    comboBox1.DataSource = dt;
    comboBox1.DataValueField = "Id";
    comboBox1.DataTextField = "Name";
    comboBox1.DataBind();
        }
    }
