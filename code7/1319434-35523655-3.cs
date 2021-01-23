    string command = string.Format(@"SELECT Name, Post, Company, Country, Email, Mobile, Tel1, Tel2, Fax, Address FROM BC where {0} LIKE @value", combobox1.Text); 
    DataTable dt;
    using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Seif-\Documents\Visual Studio 2013\Projects\BusinessCard\BusinessCard\BusinessCards.mdf;Integrated Security=True"))
    {
    	SqlCommand sc = new SqlCommand(command, conn);
	    sc.Parameters.Add("@value", textBox1.Text);
    	SqlDataAdapter sda = new SqlDataAdapter(sc);
	    dt = new DataTable();
	    sda.Fill(dt);
    }
    Search f2 = new Search(dt);
    f2.Show();
