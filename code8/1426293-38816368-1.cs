    rivate int Fetch_Room()
            {
                int number = 0;
                try
                {
                    String str = "SELECT room_NO FROM booking WHERE tourist_CNIC='" + cnic.Content.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(str, con);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                      {
                         number = (int)rdr.GetValue(0);
                      }
                    return number;
                 }
               catch (Exception x) { MessageBox.Show("Error: " + x.Message); return number; }
            }
