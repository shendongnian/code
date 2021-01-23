    private void ButtonOk_Click(object sender, EventArgs e)
    {
        if (txtWedstrijdSchemaID.Text == "")
        {
        SqlCommand cmd = new SqlCommand("Insert into Wedstrijdschema (Team1, Team2, Datum)  values (@Team1,@Team2,@datetime)"); 
         cmd.Parameters.AddWithValue("@Team1",txtTeam1.Text 
         cmd.Parameters.AddWithValue("@Team2",txtTeam2.Text              
         cmd.Parameters.AddWithValue("@datetime",Convert.ToDateTime(txtDatum.Text)     
         clDatabase.ExecuteCommand(SQL);
         vulLv();
        }
        else
        {
        SqlCommand cmd = new SqlCommand("Update Wedstrijdschema SET Team1=@team1,Team2=@team2,Datum =@Datum where SchemaId=@SchemaId");
         cmd.Parameters.AddWithValue("@team1",txtTeam1.Text );
         cmd.Parameters.AddWithValue("@team2",txtTeam2.Text);              
         cmd.Parameters.AddWithValue("@Datum ",Convert.ToDateTime(txtDatum.Text);
         cmd.Parameters.AddWithValue("@SchemaId",zoek);
         clDatabase.ExecuteCommand(SQL);
         vulLv();
        }
        txtDatum.Enabled = txtTeam2.Enabled = txtTeam1.Enabled = false;
    }
