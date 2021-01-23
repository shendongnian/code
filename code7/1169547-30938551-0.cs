    private void ButtonOk_Click(object sender, EventArgs e)
            {
                if (txtWedstrijdSchemaID.Text == "")
                {
                    //Insert
                    string SQL;
                    SQL = "Insert into Wedstrijdschema (Team1, Team2,**Datum**)";
                    SQL += " values (";
                    SQL += "" + txtTeam1.Text + ",";
                    SQL += "" + txtTeam2.Text + "";
                    SQL += "" + Convert.ToDateTime(txtDatum.Text) + "";
                    SQL += ")";
    
                    clDatabase.ExecuteCommand(SQL);
                    vulLv();
                }
                else
                {
                    //Update
                    string SQL;
                    SQL = "Update Wedstrijdschema SET ";
                    SQL += "Team1 = " + txtTeam1.Text + ",";
                    SQL += "Team2 = " + txtTeam2.Text + "";
                    SQL += "Datum = " + Convert.ToDateTime(txtDatum.Text) + "";
                    SQL += " where SchemaId = " + zoek;
    
                    clDatabase.ExecuteCommand(SQL);
                    vulLv();
                }
                txtDatum.Enabled = txtTeam2.Enabled = txtTeam1.Enabled = false;
            }
