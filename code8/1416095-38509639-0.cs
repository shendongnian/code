    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["*******"].ConnectionString;
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            string query = "SELECT one, two, three FROM table WHERE id = " + TextBox1.Text; // this should be parameterized
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            int nRows = dt.Rows.Count;
            if (nRows == 0)
            {
                GridView1.Visible = false;
            }
            else
            {
                GridView1.Visible = true;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                DataRow firstRow = dt.Rows[0];
                string value1 = firstRow[0].ToString();
                string value2 = firstRow[1].ToString();
                string value3 = firstRow[2].ToString();
                myDrowDownList1.SelectedValue = value1;
                myDrowDownList2.SelectedValue = value2;
                myDrowDownList3.SelectedValue = value3;
            }
        }
    }
