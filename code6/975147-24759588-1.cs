    public void getFallingCategory(object sender, EventArgs e)
    {
        brandNameUpdated.Text = getBrandForUpdate.Text;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ravissantCon"].ConnectionString);
        con.Open();
        string getUser = "SELECT category FROM brands WHERE brandName = '" + getBrandForUpdate.Text + "'";
        SqlCommand cmd = new SqlCommand(getUser, con);
        SqlDataReader sdr = cmd.ExecuteReader();
        if (sdr.HasRows)
        {
            while (sdr.Read())
            {
                getCategoryOfBrand.SelectedValue = sdr["category"].ToString();
            }
        }
        sdr.Close();
        con.Close();
    }
