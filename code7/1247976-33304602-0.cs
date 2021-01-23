    protected void BtnDecideForMe_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Data Source=DEV-116\\ONLINE;Initial Catalog=PaydayLunch;Integrated Security=True";
        //using (SqlConnection conn = new SqlConnection(PaydayLunchConnectionString1))
        using (SqlCommand cmd = new SqlCommand("dbo.GetRandomPlace", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            // set up the parameters
            cmd.Parameters.Add("@OutputVar", SqlDbType.VarChar, 25).Direction = ParameterDirection.Output;
            
            // open connection and execute stored procedure
            conn.Open();
            cmd.ExecuteNonQuery();
            // read output value from @OutputVar
            string place = Convert.ToString(cmd.Parameters["@OutputVar"].Value);
            conn.Close();
            txtDestination.Text = place;
        }
    }
