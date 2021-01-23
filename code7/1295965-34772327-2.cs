    lblUserName.Text=txtUserName.Text;
    
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0 AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True");
    private void button1_Click(object sender, EventArgs e)
    {
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Login WHERE username='"+lblUserName.Text+"'", con);
        DataSet DATA = new DataSet();
        sda.Fill(DATA);
        dataGridView1.DataSource = DATA;
        con.Close();
    } 
