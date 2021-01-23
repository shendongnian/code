    private void button2_Click(object sender, EventArgs e)
    {
        using(OleDbConnection Conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=BoilerSvc_be.mdb"))
		{
			OleDbCommand command = new OleDbCommand();
			 
			command.CommandText = "INSERT INTO Contacts (Title,Initial,Surname,[Address 1],[Address 2],[Address 3],[Post Town],[Post Code],Telephone,Archived) VALUES (@Title,@FirstName,@LastName,@Address1,@Address2,@Address3,@PostTown,@PostCode,@Telephone,0)";
			 
			command.Parameters.AddWithValue("@FirstName", string.IsNullOrEmpty(FirstName.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@LastName", string.IsNullOrEmpty(LastName.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@Address1", string.IsNullOrEmpty(Address1.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@Address2", string.IsNullOrEmpty(Address2.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@Address3", string.IsNullOrEmpty(Address3.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@PostCode", string.IsNullOrEmpty(Postcode.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@PostTown", string.IsNullOrEmpty(TownCity.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@Telephone", string.IsNullOrEmpty(PhnNum.Text) ? DBNull.Value : title.Text);
			command.Parameters.AddWithValue("@Title", string.IsNullOrEmpty(Titl.Text) ? DBNull.Value : title.Text);
		
			Conn.Open();
			command.Connection = Conn;
			command.ExecuteNonQuery();
		}
		
		FirstName.Text = null;
		LastName.Text = null;
		Address1.Text = null;
		Address2.Text = null;
		Address2.Text = null;
		Postcode.Text = null;
		TownCity.Text = null;
		Title.Text = null;
		PhnNum.Text = null;
		Address3.Text = null;
	
		MessageBox.Show("Customer Added");
    }
