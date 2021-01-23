      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
              string query = "SELECT Name, DateofBirth FROM TableName Where ID ="+comboBox1.Text;
        SqlConnection sqlConn = new SqlConnection(conSTR);
        sqlConn.Open();
        SqlCommand cmd = new SqlCommand(query, sqlConn);
        SqlDataAdapter da=new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
       textBox1.Text = dt.Rows[0]["Name"].ToString();
       datePicker1.Text = dt.Rows[0]["DateOfBirth"].ToString(); 
           
        }
