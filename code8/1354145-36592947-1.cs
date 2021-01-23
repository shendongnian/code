    using(SqlConnection con = new SqlConnection(.....))
    using(SqlCommand cmd = new SqlCommand(cmdText, con))
    {
       con.Open();
       cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = txtGebruikersnaam.Text;
       cmd.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = txtPaswoord.Text;
       cmd.Parameters.Add("@type", SqlDbType.NVarChar).Value = Accounttype;
       int countType = Convert.ToInt32(cmd.ExecuteScalar());
       if(countType == 0)
          MessageBox.Show("No user found for the type requested");
       else
       {
           if (Accounttype == "1")
           {
                this.Hide();
                FormAdmin ss = new FormAdmin();
                ss.Show();
           }
           else if (Accounttype == "0")
           {
                this.Hide();
                FormWerknemer ss = new FormWerknemer();
                ss.Show();
            }
        }
    }
