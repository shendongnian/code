    private void select_btn_Click(object sender, EventArgs e)
    {
      string today = (System.DateTime.Now.DayOfWeek.ToString());
      string colName = lunchTimes.Text;
      string constring = "......";
      string Query2 = "select " + colName + " from database.timeslots2 " + 
                      "where day= @day";
      using(MySqlConnection conDataBase2 = new MySqlConnection(constring))
      using(MySqlCommand cmdDataBase2 = new MySqlCommand(Query2, conDataBase2))
      {
         conDataBase2.Open();
         cmdDataBase2.Parameters.Add("@day", MySqlDbType.VarChar).Value = today;
         using(MySqlDataReader reader = cmdDataBase2.ExecuteReader())
         {
             while(reader.Read())
                 Console.WriteLine(today + " value is " + reader[0].ToString());
         }
      }
    }
