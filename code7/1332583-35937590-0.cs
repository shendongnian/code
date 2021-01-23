    public void loadnow()
    {
    
        cn = new SqlConnection(str);
        cn.Open();
        cmd = new SqlCommand("select EmployeeName=[EmployeeFirstName]+' '+[EmployeeLastName] from EmployeeMaster ", cn);
        cmd.ExecuteNonQuery();
        da = new SqlDataAdapter(cmd);
        ds = new DataSet();
        da.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            StringBuilder sb = new StringBuilder();
    
            foreach (DataRow myRow in ds.Tables[0].Rows)
            {
                sb.Append(ds.Tables[0].Rows[0]["EmployeeName"].ToString());
                sb.Append(Environment.NewLine);
    
            }
    
            TextBox1.Text = sb.ToString();
    
            cn.Close();
        }
    }
