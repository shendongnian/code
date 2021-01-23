    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    String getquery;
    getquery = DropDownList1.Text;
    MySqlConnection Con = new MySqlConnection(ConnStr);
    Con.Open();
    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM finalproject.truckinfo WHERE truckplateno='" + getquery + "'", Con);
    da.Fill(dt);
    if (dt.Rows.Count > 0)
    {
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    Con.Close();
    
    }
