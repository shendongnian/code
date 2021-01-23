    private void button1_Click(object sender, EventArgs e)
    {
        this.Hide();
        SqlConnection conn = new SqlConnection(@"<your connection string>");
        SqlCommand sc = new SqlCommand(string.Format(@"
            SELECT Name, Post, Company, Country, Email, Mobile, Tel1, Tel2, Fax, Address
            FROM BC
            where {0} like @VAL", comboBox1.Text), conn);
        sc.Parameters.AddWithValue("@VAL", textBox1.Text);
        SqlDataAdapter sda = new SqlDataAdapter(sc);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        var = (string)sc.ExecuteScalar();
        Search f2 = new Search();
        f2.Show();
    }
