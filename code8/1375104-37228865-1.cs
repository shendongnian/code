	SqlCommand verifica = new SqlCommand();
	verifica.CommandText = "select * from [Users]";
	verifica.Connection = con;
	SqlDataReader rd = verifica.ExecuteReader();
	while (rd.Read())
	{
		if (rd[1].ToString() == tbUname.Text || rd[3].ToString() == tbEmail.Text)
		{
			flag = true;
			break;
		}
	}
	if (flag == true)
	{
		if (rd[1].ToString() == tbUname.Text)
		{
			lblMsg.Text = "Username already exists!";
		}
		if (rd[3].ToString() == tbEmail.Text)
		{
			lblMsg.Text = "Email already exists in the database!";
		}
	}
