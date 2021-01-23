    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string query = "select * from Employee where Employee_ID='" + DropDownList1.SelectedValue.ToString() + "'";
        
        conn.Open();
        cmd = new SqlCommand(query, con);
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            DropDownList1.Items.Add(dr["<column_name>"].ToString());
        }
        con.Close();
    }
