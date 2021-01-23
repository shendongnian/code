    private void tableListBox_SelectedValueChanged(object sender, EventArgs e)
    {
        string constring = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\IncomerDefault.mdf;Integrated Security=True;Connect Timeout=30";
        string Query = "SELECT * FROM [Table] WHERE ID = '" + tableListBox.SelectedIndex.ToString() + "'";
        SqlConnection con = new SqlConnection(constring);
        SqlCommand cmd = new SqlCommand(Query, con);
        SqlDataReader Reader;
        try
        {
            con.Open();
            Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                textBox1.Text = Reader.GetValue(2).ToString();
                comboBox1.Text = Reader.GetValue(3).ToString();
                comboBox3.Text = Reader.GetValue(4).ToString();
                textBox2.Text = Reader.GetValue(6).ToString();
                comboBox2.Text = Reader.GetValue(7).ToString();
                comboBox4.Text = Reader.GetValue(8).ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        con.Close();
    }
