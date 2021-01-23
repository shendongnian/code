    MySqlCommand cmd = new MySqlCommand("SELECT name,calorificValue FROM myfitsecret.food where name=@name", cnn);
    string s = (comboBox1.SelectedItem).ToString();
    cmd.Parameters.AddWithValue("@name",s);
    MySqlCommand cmd2 = new MySqlCommand("SELECT SUM(daily_gained) FROM myfitsecret.calorie_tracker where sportsman_id=@sportsman_id", cnn);
    cmd2.Parameters.AddWithValue("@sportsman_id", Login.userID);
    cnn.Open();
    MySqlDataReader rd = cmd.ExecuteReader();
    if (rd.HasRows) // if entered username and password have data
    {
        while (rd.Read()) // while the reader can read 
        {
            burned += int.Parse(rd["calorificValue"].ToString());
        }
    }
    burned = cmd2.ExecuteScalar();
    MessageBox.Show(burned+"");
    cnn.Close();
