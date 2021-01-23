    string sql = "SELECT * FROM bus_seats WHERE sefer_id = 1";
    using (SQLiteCommand command = new SQLiteCommand(sql, connect))
    {
         SQLiteDataReader reader = command.ExecuteReader();
         while (reader.Read())
         {
             var seat = reader["seatNumber"].ToString();
             var chk = string.Format("checkBox{0}", seat);
    
             if (reader["seatTaken"].ToString() == "1")
             {
                 ((CheckBox)form1.FindControl(chk)).BackColor = Color.CornflowerBlue;
             }
         }
    }
