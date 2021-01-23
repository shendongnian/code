	private void txtBox1_LostFocus(object sender, RoutedEventArgs e)
	{
		SqlConnection mySC = new SqlConnection();
		SqlDataReader reader;
		mySC.ConnectionString = ("Data Source=localhost;Initial Catalog=RCA;Integrated Security=True");
		mySC.Open();
		string sql = @"SELECT * FROM RCA Where Ticketid = @tktid;";
		using(var command = new SqlCommand(sql, mySC))
		{
			command.Parameters.Add("@tktid", txtBox1.Text);
			reader = command.ExecuteReader();
		}
		if(reader.HasRows)
		{
			//Here you change the Label with LabelName I have used string to show.
			string Lbllabel = "Change";
			txtEmail.IsEnabled = true;
		}
		mySC.Close();
	}
