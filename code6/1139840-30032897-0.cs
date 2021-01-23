    if (dr.HasRows)
    {
        while (dr.Read())
        {
            textBox2.Text = dr[0].ToString();
            textBox3.Text = dr[1].ToString();
        }
    }
    else
    {
        MessageBox.Show("No record is found with this number >> " + textBox1.Text.ToString());
    }
