    // This is First Button
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        // What does theis code here do ??
        SqlConnection con = Connection.DBconnection();
        {
            SqlCommand com = new SqlCommand("PROCEDURE_SELECT", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", txtstudentid.Text.Trim());
            SqlDataAdapter adp = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            // SEt value to TextBox & make sure your value below is not Null else it will throw you null exception due to you use .ToString()
            txttamil.Text = ds.Tables[0].Rows[0]["Tamil"].ToString();
            txtenglish.Text = ds.Tables[0].Rows[0]["English"].ToString();
            txtmaths.Text = ds.Tables[0].Rows[0]["Maths"].ToString();
            txtscience.Text = ds.Tables[0].Rows[0]["Science"].ToString();
            txtsocialscience.Text = ds.Tables[0].Rows[0]["SocialScience"].ToString();
        }    
    }
    // This is second Button
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = Connection.DBconnection())
        {
            using (SqlCommand cmd = new SqlCommand("PROCEDURE_UPDATE", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                // Add your Parameter
                cmd.Parameters.AddWithValue("@id", txtstudentid.Text.Trim());
                cmd.Parameters.AddWithValue("@tamil", txttamil.Text.Trim());
                cmd.Parameters.AddWithValue("@english", txtenglish.Text.Trim());
                cmd.Parameters.AddWithValue("@math", txtmaths.Text.Trim());
                cmd.Parameters.AddWithValue("@science", txtscience.Text.Trim());
                cmd.Parameters.AddWithValue("@socialScience", txtsocialscience.Text.Trim());
                con.Open();
                // Execute your Query
                cmd.ExecuteNonQuery();
                // Clear All The Data in Current TextBOx and press search again with the ID
                txttamil.Text = string.Empty;
                txtenglish.Text = string.Empty;
                txtmaths.Text = string.Empty;
                txtscience.Text = string.Empty;
                txtsocialscience.Text = string.Empty;
                Response.Write("You have updated the value... Try to Search again...");
            }
            // UPDATE Query as per below
            // IF EXISTS (SELECT * FROM studentresult WHERE id_student='@id') 
            // BEGIN
            //     UPDATE TABLE SET tamil = @tamil and so on... WHERE id = @id
            // END
            // ELSE
            // BEGIN
            //     INSERT DATA HERE
            // END
        }
    }
