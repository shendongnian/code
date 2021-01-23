    private void SaveButton_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("Data Source=PC308433;Initial Catalog=SampleDatabase;Persist Security Info=True;User ID=sa;Password=adm23");
        conn.Open();
        SqlCommand sc = new SqlCommand("select USERNAME from QuizTable where USERNAME='" + UserNameTextbox.Text + "'", conn);
        SqlDataReader dr = sc.ExecuteReader();//Use this line
        if (dr.HasRows)
            MessageBox.Show("Welcome");
        else
            MessageBox.Show("Please register");
        conn.Close();
    }
