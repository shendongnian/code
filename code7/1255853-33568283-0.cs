    private void button4_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection CON = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VS_project\\WindowsFormsApplication1\\WindowsFormsApplication1\\myInfo.mdf;Integrated Security=True"))
            {
                CON.Open();
                SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO myInfo(Name,Address,Gender,LangKnownHindi)VALUES(@Name,@Address,@Gender,@LangKnownHindi)", CON);
                SDA.SelectCommand.Parameters.AddWithValue("@Name", textBox1.Text);
                SDA.SelectCommand.Parameters.AddWithValue("@Address", textBox2.Text);
                SDA.SelectCommand.Parameters.AddWithValue("@Gender", Gender);
                SDA.SelectCommand.Parameters.AddWithValue("@LangKnownHindi", LANG_Hin);
                SDA.SelectCommand.ExecuteNonQuery();
                CON.Close();
            }
            MessageBox.Show("Saved SuccessFully!!!!!");
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
