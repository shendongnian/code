	using(SqlConnection vid = new SqlConnection("Data Source=JOSAN;Initial Catalog=AdventureWorks2012;Integrated Security=True"))
	{
		using(SqlCommand xp = new SqlCommand())
		{
			xp.CommandText = @"Insert into HumanResources.Employee(NationalIDNumber, LoginID, JobTitle, BirthDate, MaritalStatus, Gender, HireDate, SalariedFlag, VacationHours, SickLeaveHours, CurrentFlag, ModifiedDate) Values(@NationalIDNumber, @loginID, @JobTitle, @BirthDate, @MaritalStatus, @Gender, @HireDate, @SalariedFlag, @VacationHours, @SickLeaveHours, @CurrentFlag, @ModifiedDate)"; 
			xp.Connection = vid;
			xp.Parameters.AddWithValue("@NationalIDNumber", Convert.ToInt32(TextBox1.Text));
			xp.Parameters.AddWithValue("@LoginID", TextBox2.Text);
			xp.Parameters.AddWithValue("@JobTitle", TextBox3.Text);
			xp.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime(TextBox4.Text));
			xp.Parameters.AddWithValue("@MaritalStatus", Convert.ToChar(TextBox5.Text));
			xp.Parameters.AddWithValue("@Gender", Convert.ToChar(TextBox6.Text));
			xp.Parameters.AddWithValue("@HireDate", Convert.ToDateTime(TextBox7.Text));
			xp.Parameters.AddWithValue("@SalariedFlag", Convert.ToInt32(TextBox8.Text));
			xp.Parameters.AddWithValue("@VacationHours", Convert.ToInt32(TextBox9.Text));
			xp.Parameters.AddWithValue("@SickLeaveHours", Convert.ToInt32(TextBox10.Text));
			xp.Parameters.AddWithValue("@CurrentFlag", Convert.ToInt32(TextBox11.Text));
			xp.Parameters.AddWithValue("@ModifiedDate", Convert.ToDateTime(TextBox12.Text));
			try
			{
				vid.Open();
				xp.ExecuteNonQuery();
			}
			catch
			{
				MessgeBox.Show(e.Message.ToString(), "Error Message");
				vid.Close();
			}
			if (IsPostBack)
			{
				TextBox1.Text = "";
				TextBox2.Text = "";
				TextBox3.Text = "";
				TextBox4.Text = "";
				TextBox5.Text = "";
				TextBox6.Text = "";
				TextBox7.Text = "";
				TextBox8.Text = "";
				TextBox9.Text = "";
				TextBox10.Text = "";
				TextBox11.Text = "";
				TextBox12.Text = "";
			}
		}
	}
