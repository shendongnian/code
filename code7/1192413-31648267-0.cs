    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue !="-1"){
            string ddl2value = DropDownList1.SelectedValue.ToString();
            SqlConnection objConn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand objCmd2;
            SqlDataReader objRdr2;
            objConn2.Open();
    
            objCmd2 = new SqlCommand("SELECT code, rank, address FROM agen_mast WHERE name = " +
            "'" + ddl2value.ToString() + "'", objConn2);
            objRdr2 = objCmd2.ExecuteReader();
    
            while (objRdr2.Read())
            {
    
                TextBox9.Text = (string)objRdr2["code"].ToString();
                TextBox8.Text = (string)objRdr2["address"].ToString().ToUpper();
                TextBox10.Text = (string)objRdr2["rank"].ToString().ToUpper();
            }
    
            objRdr2.Close();
            objConn2.Close();
            }
        }
