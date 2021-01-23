    protected void btnsearch_Click(object sender, EventArgs e)
    {
        SqlConnection con = Connection.DBconnection();
    
        SqlCommand com = new SqlCommand("sp_studentresult", con);
        com.CommandType = CommandType.StoredProcedure;
    
        com.Parameters.AddWithValue("@id", textstudentid.Text);
        com.Parameters.AddWithValue("@id_student", textIDStudent.Text);
        SqlParameter retval2 = new SqlParameter("@output", SqlDbType.VarChar, 50);
        retval2.Direction = ParameterDirection.Output;
        com.Parameters.Add(retval2);
    
        SqlDataAdapter adp = new SqlDataAdapter(com);
        DataSet ds = new DataSet();
        adp.Fill(ds);
    
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtid.Text = ds.Tables[0].Rows[0]["id"].ToString();
            txttamil.Text = ds.Tables[0].Rows[0]["Tamil"].ToString();
            txtenglish.Text = ds.Tables[0].Rows[0]["English"].ToString();
            txtmaths.Text = ds.Tables[0].Rows[0]["Maths"].ToString();
            txtscience.Text = ds.Tables[0].Rows[0]["Science"].ToString();
            txtsocialscience.Text = ds.Tables[0].Rows[0]["SocialScience"].ToString();
        }
    
        SqlParameter retval = new SqlParameter("@output", SqlDbType.VarChar, 50);
        retval.Direction = ParameterDirection.Output;
        com.Parameters.Add(retval);
        com.Parameters.AddWithValue("@id", textstudentid.Text);
        com.Parameters.AddWithValue("@id_student", textIDStudent.Text);
    
        com.ExecuteNonQuery();
    
        string Output = retval.Value.ToString();
    }
