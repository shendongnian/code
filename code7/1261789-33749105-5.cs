    private void button3_Click(object sender, EventArgs e)
	{
		SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|Data.mdf;Integrated Security=True");
		SqlDataAdapter sda = new SqlDataAdapter("Select Role from Login Where UserName='" + textBox1.Text + "' and Password='" + textBox2.Text + "'   ",con);
		DataTable dt = new System.Data.DataTable();
		sda.Fill(dt);
		if(dt.Rows.Count == 1)
		{
			switch (dt.Rows[0]["Role"] as string)
			{
				case "Admin":
					{
						this.Hide();
						AdminMenu ss = new AdminMenu();
						ss.Show();
						break;
					}
				case "Client":
					{
						this.Hide();
						MenuForm mf = new MenuForm();
						mf.Show();
						break;
					}
				default:
					{
						MessageBox.Show("Please contact your administrator");
						break;
					}
			}
		}
		else
		{
			MessageBox.Show("Login Details are incorrect.");
		}
	}
