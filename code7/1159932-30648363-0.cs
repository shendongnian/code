        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\vicky\Desktop\Gym management system\Fitness_club\vicky.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * FROM [plan] where plantype='" + comboBox1.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string amount = dr.GetString(1);
                textBox5.Text = amount;
            }
            // check if connection is open
            if (con.State == 1)
                con.Close();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            // check if connection is open
            if (con.State == 1)
                con.Close();
        }
}
