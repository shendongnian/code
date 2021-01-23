	private void btnLogin_Click(object sender, EventArgs e)
	{
		if (CheckUserPassword())
		{
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		else MessageBox.Show("Login failed!");
	}
