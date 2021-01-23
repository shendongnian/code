    private void button4_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VS_project\\WindowsFormsApplication1\\WindowsFormsApplication1\\myInfo.mdf;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO myInfo(Name,Address,Gender,LangKnownHindi)VALUES(@name, @address,@gender,@lang)", conn))
                {
                    command.Parameters.AddWithValue("@name", textBox1.Text);
                    command.Parameters.AddWithValue("@address", textBox2.Text);
                    command.Parameters.AddWithValue("@gender", Gender);
                    command.Parameters.AddWithValue("@lang", LANG_Hin);
                    command.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Saved SuccessFully!!!!!");
            }
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
    
        }
    }
