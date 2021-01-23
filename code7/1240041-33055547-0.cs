    protected void cmdUpdate_Click(object sender, EventArgs e)
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;" + 
            "pwd=password;database=ddt_data");
        conn.Open();
        string command = "UPDATE fixture SET referee=@referee, scorea=@scorea, " +
            "scoreb=@scoreb, winner=@winner WHERE idfixture=@idfixture";
        MySqlCommmand update = new MySqlCommand(command, conn);
        update.Parameters.AddWithValue("@referee", this.txtRef.Text);
        update.Parameters.AddWithValue("@scorea", this.txtScoreA.Text);
        update.Parameters.AddWithValue("@scoreb", this.txtScoreB.Text);
        update.Parameters.AddWithValue("@winner", this.txtWinner.Text);
        update.Parameters.AddWithValue("idfixture", this.txtFixtureID.Text);
        
        // not sure what you want to achieve from this
        // MySqlDataReader reader = update.ExecuteReader();
        // while (reader.Read())
        // {
             // do something here?
        // }
    
        update.ExecuteNonQuery(); // use this if you don't need the DataReader
        conn.Close();
        conn.Dispose();
        Response.Redirect("FixtureEdit.aspx");
    
    }
