    private void button1_Click(object sender, EventArgs e)
    
    {
        SqlConnection con = new System.Data.SqlClient.SqlConnection();
        con = new System.Data.SqlClient.SqlConnection();
        con.ConnectionString = "Server='server_name';Database='database_name';Trusted_Connection=True;";
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter();
        for (int i = 0; i <= dataGridView1.Rows.Count - 2; i++)
        {
            String insertData = "INSERT INTO Import_List(Fname, Lname, Age) VALUES (@Fname, @Lname, @Age)";
            SqlCommand cmd = new SqlCommand(insertData, con);
            cmd.Parameters.AddWithValue("@Fname", dataGridView1.Rows[i].Cells[0].Value);
            cmd.Parameters.AddWithValue("@Lname", dataGridView1.Rows[i].Cells[1].Value);
            cmd.Parameters.AddWithValue("@Age", dataGridView1.Rows[i].Cells[2].Value);
            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
        }
        con.Close();
    }
