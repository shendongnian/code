	using(var con = new SqlConnection("connectionStringHere"))
	{
		if (userCount > 1)
		{
			Label4.Text = "Record Already Exists in the database. Overwriting the previous existing files.";
			//UPDATE STATEMENT
			string entrytime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
			string ip = Request.UserHostAddress;
			using(SqlCommand upd = new SqlCommand("UPDATE DoctorActivity SET(Computer_Id=@Computer_Id, Duty_Date=@Duty_Date, Duty_Type=@Duty_Type, OPD=@OPD, Minor_OT=@Minor_OT, Major_OT=@Major_OT, Normal_Delivery=@Normal_Delivery, Cesarean_Delivery=@Cesarean_Delivery, DateOfEntry=@DateOfEntry, IP=@IP, User_Id=@User_Id)", con))
			{
				upd.CommandType = CommandType.Text;
				upd.Parameters.AddWithValue("@Computer_Id", GridView1.Rows[i].Cells[0].Text);
				upd.Parameters.AddWithValue("@Duty_Date", GridView1.Rows[i].Cells[1].Text);
				upd.Parameters.AddWithValue("@Duty_Type", GridView1.Rows[i].Cells[2].Text);
				upd.Parameters.AddWithValue("@OPD", GridView1.Rows[i].Cells[3].Text);
				upd.Parameters.AddWithValue("@Minor_OT", GridView1.Rows[i].Cells[4].Text);
				upd.Parameters.AddWithValue("@Major_OT", GridView1.Rows[i].Cells[5].Text);
				upd.Parameters.AddWithValue("@Normal_Delivery", GridView1.Rows[i].Cells[6].Text);
				upd.Parameters.AddWithValue("@Cesarean_Delivery", GridView1.Rows[i].Cells[7].Text);
				upd.Parameters.AddWithValue("@IP", ip);
				upd.Parameters.AddWithValue("@DateOfEntry", entrytime);
				upd.Parameters.AddWithValue("@User_Id", GetUsername());
				
				cmd.ExecuteNonQuery(); // added
			}
		}
		else{
			//INSERT STATEMENT
			string statment = string.Format("INSERT INTO DoctorActivity(Computer_Id, Duty_Date, Duty_Type, OPD, Minor_OT, Major_OT, Normal_Delivery, Cesarean_Delivery,DateOfEntry, IP, User_Id) VALUES ('" + GridView1.Rows[i].Cells[0].Text + "', '" + GridView1.Rows[i].Cells[1].Text + "', '" + GridView1.Rows[i].Cells[2].Text + "', '" + GridView1.Rows[i].Cells[3].Text + "', '" + GridView1.Rows[i].Cells[4].Text + "', '" + GridView1.Rows[i].Cells[5].Text + "', '" + GridView1.Rows[i].Cells[6].Text + "', '" + GridView1.Rows[i].Cells[7].Text + "',@DateOfEntry, @IP, @User_Id)");
			string entrytime = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
			string ip = Request.UserHostAddress;
			using(SqlCommand cmd = new SqlCommand(statment, con))
			{
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddWithValue("@IP", ip);
				cmd.Parameters.AddWithValue("@DateOfEntry", entrytime);
				cmd.Parameters.AddWithValue("@User_Id", GetUsername());
				cmd.ExecuteNonQuery();
			}
			Label1.Text = "File Uploaded Succesfully";
		}
	}
