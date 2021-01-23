    protected void BindContrydropdown()
    {
        //conenction path for database
        //string connection = WebConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Id,CityName From Career.Location", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            ddllocation1.DataSource = ds;
            ddllocation1.DataTextField = "CityName";
            ddllocation1.DataValueField = "Id";
            ddllocation1.DataBind();
            ddllocation1.Items.Insert(0, new ListItem("--Select--", "0"));
            ddllocation1.Items.Insert(1, new ListItem("--OTHER--", "0"));
            con.Close();
        }
    }
    protected void ddllocation1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string country = "India";
        var cities = _helper.GetLocations(country, ddllocation1.SelectedValue);
        cities.Insert(0, "--Select--");
        cities.Insert(1, "Other");
        ddlLocation.DataSource = cities;
        ddlLocation.DataBind();
    }
    protected void btnAddDropDown_Click1(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(constring))
        {
            con.Open();
            //BindContrydropdown();
            //if (txtOtherCity.Text != "")
            //{
            //    txtOtherCity.Text = "";
            //}
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Add_CityforLocation";
            cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = 0;
            cmd.Parameters.Add("@CountryName", SqlDbType.VarChar).Value = "India";
            cmd.Parameters.Add("@CityName", SqlDbType.VarChar).Value = txtOtherCity.Text.Trim();
            cmd.Parameters.Add("@StateName", SqlDbType.VarChar).Value = ddlLocation.SelectedItem.ToString();
            cmd.Connection = con;
            try
            {
                // con.Open();
                cmd.ExecuteNonQuery();
                BindContrydropdown();
                // lblMessage.Text = "City inserted successfully!";
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);//You Can Haave Messagebox here
            }
            finally
            {
                con.Close();
            }
        }
    }
