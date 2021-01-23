	String copies = txtcopies.Text;
	int x = Convert.ToInt32(copies);
	int n = 0;
	string loadstring = @"server=localhost;database=librarys;userid=root;password=1234;";
	MySqlConnection conDataBase = new MySqlConnection(loadstring);
	try
	{
		conDataBase.Open();
		while (n < x)
		{
			MySqlCommand cmdDataBase = new MySqlCommand("SELECT func_add_book('" + this.lblbnum.Text + "','" + this.txtisbn.Text + "','" + this.txttitle.Text + "','" + this.txtauthor.Text + "','" + this.txtpublisher.Text + "','" + this.txtdate.Text + "','" + this.txtcost.Text + "');", conDataBase);
			string returnedValue = cmdDataBase.ExecuteScalar().ToString();
			n++;
			ClearAllText(txtcopies);
			MessageBox.Show(returnedValue);
		}
	}
	Catch (Exception Ex)
	{
	}
	Finally
	{
		conDataBase.Close()
	}
