        cmd = new SqlCommand("sp_atnd_detail",conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@userid", Login.userid);
        ad = new SqlDataAdapter(cmd);
        ds = new DataSet();
        ad.Fill(ds,0,0,"vw_EmpAtnd");
        gvDetail.DataSource = ds.Tables["vw_EmpAtnd"];
        conn.Open();
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            txtName.Text = dr["Employee"].ToString();
            txtNic.Text = dr["NIC"].ToString();
            txtUserName.Text = dr["UserName"].ToString();
            txtRole.Text = dr["Role"].ToString();
            if (!dr.IsDBNull(dr.GetOrdinal("Pic")))
            { 
                byte[] Img = (byte[])dr["Pic"];
                MemoryStream ms = new MemoryStream(Img);
                picEmp.Image = Image.FromStream(ms);
                picEmp.Refresh();
            }
            conn.Close();
            dr.Close();
        }
