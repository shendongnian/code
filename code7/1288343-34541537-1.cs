    try
    {
         //con.Open(); //Not Needed
         sda.InsertCommand = new SqlCommand("INSERT INTO tbluser VALUES ('" + user.Fname + "','" + user.Lname + "','" + user.Username + "','" + user.Age + "','" + user.Sex + "','" + user.Country + "','" + user.Password + "','" + user.SecQ + "','" + user.SecA + "')", con);
         con.Open();
         sda.InsertCommand.ExecuteNonQuery();
         con.Close();
         return true;
    }
