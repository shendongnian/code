    String ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\PatientHealthMonitor.mdf;Integrated Security=True;Connect Timeout=30";
    String Query = " INSERT INTO AlarmResponse (AlarmActivated) VALUES (@alarmTime)";
    SqlConnection Con = new SqlConnection(ConStr);
    SqlCommand Command = new SqlCommand(Query, Con);
    Con.Open();
    Command.Parameters.AddWithValue("@alarmTime", DateTime.Now);
    Command.ExecuteNonQuery();
    Con.Close();
