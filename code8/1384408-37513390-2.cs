     SqlDataAdapter command = new SqlDataAdapter("select TOP 1 * from tblLogin where Gebruikersnaam = @Gebruiker and GeheimeVraag = @GeheimeVraag and Antwoord = @Antwoord", con);
            DataTable dt = new DataTable();
            command.SelectCommand.Parameters.AddWithValue("@Gebruiker", txtGebruikersnaam.Text);
            command.SelectCommand.Parameters.AddWithValue("@GeheimeVraag", ddlGeheimeVraag.Text);
            command.SelectCommand.Parameters.AddWithValue("@Antwoord", txtAntwoord.Text);
            command.Fill(dt);
    
 
     if(dt!=null)
        {
          if(dt.Rows.Count>0)
           {
                    this.Hide();
                    FormLoginWW2 ss = new FormLoginWW2();
                    ss.Show();
                }
         else
                {
                    MessageBox.Show("Error");
                }
        }
               
               
