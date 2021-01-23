    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
    {
        MessageBox.Show("No Username and/or Password Found!");
    }
    else
    {
        DataTable dtResult = new DataTable();
        string Command = "select * from southpoint_school.user where userUsername=@un and userPassword=@up";
        using (MySqlConnection myConnection = new MySqlConnection(ConnectionString))
        {
            using (MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(Command, myConnection))
            {
                myDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("@un", textBox1.Text));
                myDataAdapter.SelectCommand.Parameters.Add(new MySqlParameter("@up", textBox2.Text));
                myDataAdapter.Fill(dtResult);
            }
        }
        if (dtResult.Rows.Count == 1)
        {
            MessageBox.Show("Login successful!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if ((string)dtResult.Rows[0]["userAccountType"] == "Administrator")
            {
                memorable = "Administrator";
                frm_main main = new frm_main();
                main.Show();
                this.Hide();
            }
            else
            {
                memorable = "Limited";
                frm_main main = new frm_main();
                main.Show();
                this.Hide();
            }
        }
        else if (dtResult.Rows.Count == 0)
        {
            MessageBox.Show("Invalid Username And/Or Password!");
        }
        else //TODO: treat the case for multiple results
        {
        }
    }
