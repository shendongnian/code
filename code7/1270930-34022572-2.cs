    string ConStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\PatientHealthMonitor.mdf;Integrated Security=True;Connect Timeout=30"
    using(var Con = new SqlConnection(ConStr))
    using(var Command = Con.CreateCommand())
    {
       Command.CommandText = "INSERT INTO AlarmResponse (AlarmActivated) VALUES (@alarm)";
       Command.Parameters.Add("@alarm", SqlDbType.DateTime2).Value = DateTime.Now;
       Con.Open();
       Command.ExecuteNonQuery();
    }
