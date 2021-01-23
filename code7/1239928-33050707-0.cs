    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
     {
        try
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT Gname,Gcontactno FROM GuestInfo WHERE Groomno= '" + comboBox2.Text + "'", conn);
            OleDbDataReader  dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }
            conn.Close();
        }
        catch (Exception er)
        {
            MessageBox.Show("Error! " + er.Message);
        }
    }
