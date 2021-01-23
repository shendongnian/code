    con.Open();
    cmd = new SqlCommand(@"Select Room_Name From Rooms", con);
    rdr = cmd.ExecuteReader();
    while (rdr.Read())
    {
         roomname = rdr["Room_Name"].ToString();
         if (txtRoom.Text != roomname)
         {
             MessageBox.Show("Room is invalid.");
             txtRoom.Focus();
             return;
         }                       
    }
    rdr.Close();
    con.Close();
