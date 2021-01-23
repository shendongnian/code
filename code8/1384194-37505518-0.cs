    private void searchButton_Click(object sender, EventArgs e)
    {
        string constring = "datasource=localhost;port=3306;Initial Catalog = 'dbcpu'; username = root; password =";
        
		string whereCondition = "WHERE UserFname = @SearchInput OR  UserLname = @SearchInput";
        int searchId = 0;
        if(int.TryParse(maskedTextBox1.Text, out searchId))
		  whereCondition = "WHERE UserID = @SearchInput";
			
	    string query = "select * from admin " + whereCondition;
        
        MySqlConnection conDataBase = new MySqlConnection(constring);
 		MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);				    
        cmdDataBase.Parameters.AddWithValue("@SearchInput", maskedTextBox1.Text);    
                    
			
        MySqlDataReader myReader;
        try
        {
            conDataBase.Open();
            myReader = cmdDataBase.ExecuteReader();
            while (myReader.Read())
            {
                string Idnum = myReader.GetString(myReader.GetOrdinal("UserID"));
                label1.Text = Idnum;
                string Lname = myReader.GetString(myReader.GetOrdinal("UserLname"));
                Lname1.Text = Lname;
                string Fname = myReader.GetString(myReader.GetOrdinal("UserFname"));
                Fname1.Text = Fname;
                string Mname = myReader.GetString(myReader.GetOrdinal("UserMname"));
                Mname1.Text = Mname;
                string Gender = myReader.GetString(myReader.GetOrdinal("UserGender"));
                Gend1.Text = Gender;
                string Pos = myReader.GetString(myReader.GetOrdinal("Administrative"));
                Pos1.Text = Pos;
                string Dept = myReader.GetString(myReader.GetOrdinal("UserDepartment"));
                Off1.Text = Dept;
                byte[] imgg = (byte[])(myReader["IDPicture"]);
                if (imgg == null)
                    pictureBox1.Image = null;
                else
                {
                    MemoryStream mstream = new MemoryStream(imgg);
                    pictureBox1.Image = Image.FromStream(mstream);
                }
            }
            conDataBase.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
