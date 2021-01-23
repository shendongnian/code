	using (SqlConnection con = new SqlConnection(CS))
    {
		con.Open();
		
		bool userNameExists = false;
		bool emailExists = false;
		using(SqlCommand verifica = new SqlCommand())
		{		
			//Update this query with the hints above
			verifica.CommandText = "select * from [Users]";
			verifica.Connection = con;
			using(SqlDataReader rd = verifica.ExecuteReader())
			{			
				while (rd.Read())
				{
					if (rd[1].ToString() == tbUname.Text)
					{ 
						userNameExists = true;
						break;
					}
					else if (rd[3].ToString() == tbEmail.Text)
					{
						emailExists = true;
						break;
					}
				}
			}
		}
		if (userNameExists)
		{
			lblMsg.Text = "Username already exists!";
		}
		else if (emailExists)
		{
			lblMsg.Text = "Email already exists in the database!";
		}
		else
		{
			//You should update this part too, someone could choose the username 
			// "x','','U'); DROP TABLE [Users]; --" and do a lot of damage this way
			SqlCommand cmd = new SqlCommand("insert into Users values('" + tbUname.Text + "','" + EncryptPassword(tbPass.Text) + "','" + tbEmail.Text + "','" + tbName.Text + "','" + tbHoneypot.Text + "','U')", con);
			cmd.ExecuteNonQuery();
			lblMsg.Text = "Congratulations! Registration complete!!";
			lblMsg.ForeColor = Color.Green;
			Response.Redirect("~/Login.aspx");
		}
	}
