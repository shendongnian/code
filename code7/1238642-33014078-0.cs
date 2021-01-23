    using (SqlConnection conn = new SqlConnection("Data Source=Rogue;Initial Catalog=SoftProject;Integrated Security=True"))
    {
    conn.Open();
    try
    {
    String str1 = "";
    using (SqlCommand cmd = new SqlCommand("Select PlayerName,Score from PlayerData where PlayerName = @player", conn))
    {
        cmd.Parameters.AddWithValue("@player", txtPlayer.Text);
        DataSet ds= new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
		adapter.Fill(ds);
        
        if(ds.Tables[0].Rows.Count>0)
        {
            // concatenate the two string and get the table score row
            str1 += ds.Tables[0].Rows[0]["Score"].ToString();
        }
        else
        {
            //Report error
        }
        }
        conn.Close();
      }
      catch()
      {
         MessageBox.Show("No data");
      }
    }
